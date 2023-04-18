using ENTITIES.CORE;
using REPOSITORIES.ROLE_REPO;
using SHARED.COMMON_REPO;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.ROLE_SERVICE
{
    public class RoleService : CommonService<Role>, IRoleService
    {
        public RoleService(IRoleRepo repo) : base(repo)
        {
        }
    }
}
