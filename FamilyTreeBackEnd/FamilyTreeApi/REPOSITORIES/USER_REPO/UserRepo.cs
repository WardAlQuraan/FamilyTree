using DATA_LAYER.CORE;
using DTOs.USER;
using ENTITIES.CORE;
using Microsoft.EntityFrameworkCore;
using SHARED.COMMON_REPO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPOSITORIES.USER_REPO
{
    public class UserRepo : CommonRepo<User> , IUserRepo
    {
        private CoreContext context;
        public UserRepo(CoreContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await context.User.Where(x => x.Email.ToLower() == email.ToLower() && x.IsDeleted == 0).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserInfo> GetUser(int id)
        {
            var userInfo = await (
                from u in context.User
                join r in context.Role
                on u.RoleId equals r.Id
                where u.Id == id && u.IsDeleted == 0 && r.IsDeleted == 0
                select new UserInfo() { Id = u.Id, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName, Role = r.RoleName }
                ).FirstOrDefaultAsync();
            return userInfo;
        }

        public async Task<List<UserInfo>> GetUsers()
        {
            var userInfo = await (
                from u in context.User
                join r in context.Role
                on u.RoleId equals r.Id
                where u.IsDeleted == 0 && r.IsDeleted == 0
                select new UserInfo() {Id = u.Id,  Email = u.Email, FirstName = u.FirstName, LastName = u.LastName, Role = r.RoleName }
                ).ToListAsync();
            return userInfo;
        }

    }
}
