using DTOs.USER;
using ENTITIES.CORE;
using SHARED.COMMON_REPO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPOSITORIES.USER_REPO
{
    public interface IUserRepo : ICommonRepo<User>
    {
        Task<User> GetByEmail(string email);
        Task<UserInfo> GetUser(int id);
        Task<List<UserInfo>> GetUsers();

    }
}
