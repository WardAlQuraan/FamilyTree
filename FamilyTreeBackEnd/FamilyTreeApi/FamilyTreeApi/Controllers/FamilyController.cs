using ENTITIES.TREE;
using FamilyTreeApi.Controllers.COMMON_CONTROLLER;
using REPOSITORIES.FAMILY_REPO;
using SERVICES.FAMILY_SERVICE;

namespace FamilyTreeApi.Controllers
{

    public class FamilyController : CommonController<Family>
    {
        public FamilyController(IFamilyService service) : base(service) { }
    }
}
