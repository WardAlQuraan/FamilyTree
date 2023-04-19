using ENTITIES.CORE;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using REPOSITORIES.ROLE_REPO;
using REPOSITORIES.USER_REPO;
using SERVICES.HELPER;
using SHARED.COMMON_REPO;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

        private string GenerateToken(User user,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",user.Email),
                new Claim("Role",role),
                new Claim("Id",user.Id.ToString()),
            };
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                claims: claims,
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

    }
}
