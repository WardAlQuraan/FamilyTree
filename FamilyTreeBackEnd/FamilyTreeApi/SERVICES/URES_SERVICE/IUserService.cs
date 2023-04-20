using DTOs.USER;
using ENTITIES.CORE;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.URES_SERVICE
{
    public interface IUserService : ICommonService<User>
    {
        Task<string> Login(string email, string password);
        Task<UserInfo> GetUser(int id);
        Task<List<UserInfo>> GetUsers();
    }
}
