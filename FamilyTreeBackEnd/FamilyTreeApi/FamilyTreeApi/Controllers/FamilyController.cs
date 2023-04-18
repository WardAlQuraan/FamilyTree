using ENTITIES.TREE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using REPOSITORIES.FAMILY_REPO;

namespace FamilyTreeApi.Controllers
{

    public class FamilyController : CommonController<Family>
    {
        public FamilyController(IFamilyRepo repo) : base(repo) { }
    }
}
