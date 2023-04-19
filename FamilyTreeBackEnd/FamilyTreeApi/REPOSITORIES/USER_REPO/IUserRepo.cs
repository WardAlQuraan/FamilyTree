using ENTITIES.CORE;
using SHARED.COMMON_REPO;
using System.Threading.Tasks;

namespace REPOSITORIES.USER_REPO
{
    public interface IUserRepo : ICommonRepo<User>
    {
        Task<User> GetByEmail(string email);
    }
}
