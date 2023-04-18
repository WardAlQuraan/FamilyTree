using ENTITIES.TREE;
using REPOSITORIES.FAMILY_REPO;
using SHARED.COMMON_REPO;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.FAMILY_SERVICE
{
    public class FamilyService : CommonService<Family>, IFamilyService
    {
        public FamilyService(IFamilyRepo repo) : base(repo)
        {
        }
    }
}
