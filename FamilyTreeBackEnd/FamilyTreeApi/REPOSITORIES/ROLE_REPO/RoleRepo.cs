using DATA_LAYER.CORE;
using ENTITIES.CORE;
using SHARED.COMMON_REPO;

namespace REPOSITORIES.ROLE_REPO
{
    public class RoleRepo : CommonRepo<Role>, IRoleRepo
    {
        public RoleRepo(CoreContext context) : base(context)
        {
        }
    }
}
