using ENTITIES.CORE;
using Microsoft.Extensions.Configuration;
using REPOSITORIES.ROLE_REPO;
using REPOSITORIES.USER_REPO;
using SERVICES.HELPER;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using DTOs.USER;

namespace SERVICES.URES_SERVICE
{
    public class UserService : CommonService<User>, IUserService
    {
        private readonly IUserRepo repo;
        private readonly IRoleRepo roleRepo;
        private readonly IConfiguration configuration;
        public UserService(IUserRepo repo, IRoleRepo roleRepo,IConfiguration configuration) : base(repo)
        {
            this.repo = repo;
            this.roleRepo = roleRepo;
            this.configuration = configuration;
        }

        public override async Task<int> InsertAsync(User user)
        {
            var checkByEmail = await repo.GetByEmail(user.Email);
            if (checkByEmail == null)
            {
                var roleCheckExist = await roleRepo.CheckExist(user.RoleId);
                if (roleCheckExist)
                {
                    user.Password = PasswordHasher.HashPassword(user.Password);
                    return await base.InsertAsync(user);
                    
                }
                throw new Exception($"There is no role with id = {user.RoleId}");
            }
            throw new Exception("This Email Already Exist");

        }
        public override async Task<User> UpdateAsync(User user)
        {
            user.Password = PasswordHasher.HashPassword(user.Password);
            return await base.UpdateAsync(user);
        }


        public async Task<string> Login(string email , string password)
        {

            var user = await repo.GetByEmail(email);
            if(user != null)
            {
                if(PasswordHasher.VerifyPassword(user.Password , password))
                {
                    var role = await roleRepo.GetAsync(user.RoleId);
                    return GenerateToken(user,role.RoleName);
                }
                throw new Exception("Invalid password");
            }
            throw new Exception("Invalid Email");
        }

        public async Task<UserInfo> GetUser(int id)
        {
            return await repo.GetUser(id);
        }
        public async Task<List<UserInfo>> GetUsers()
        {
            return await repo.GetUsers();
        }

        private string GenerateToken(User user,string role)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }



    }
}
