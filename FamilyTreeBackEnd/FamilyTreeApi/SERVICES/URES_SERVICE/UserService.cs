using ENTITIES.CORE;
using REPOSITORIES.USER_REPO;
using SHARED.COMMON_REPO;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.URES_SERVICE
{
    public class UserService : CommonService<User>, IUserService
    {
        public UserService(IUserRepo repo) : base(repo)
        {
        }
    }
}
