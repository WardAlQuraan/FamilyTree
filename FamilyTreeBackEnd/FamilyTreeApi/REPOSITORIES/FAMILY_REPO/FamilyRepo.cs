using DATA_LAYER.TREE;
using ENTITIES.TREE;
using SHARED.COMMON_REPO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORIES.FAMILY_REPO
{
    public class FamilyRepo:CommonRepo<Family>, IFamilyRepo
    {
        public FamilyRepo(TreeContext context) : base(context) { }
    }
}
