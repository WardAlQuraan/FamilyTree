using DATA_LAYER.CORE;
using ENTITIES.CORE;
using SHARED.COMMON_REPO;

namespace REPOSITORIES.USER_REPO
{
    public class UserRepo : CommonRepo<User> , IUserRepo
    {
        public UserRepo(CoreContext context) : base(context)
        {
        }


    }
}
