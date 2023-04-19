using ENTITIES.TREE;
using REPOSITORIES.FAMILY_REPO;
using REPOSITORIES.TREE_REPO;
using SHARED.COMMON_SERVICES;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SERVICES.TREE_SERVICE
{
    public class TreeService : CommonService<Tree>, ITreeSevice
    {
        private readonly ITreeRepo repo;
        private readonly IFamilyRepo familyRepo;
        public TreeService(ITreeRepo repo , IFamilyRepo familyRepo ) : base(repo)
        {
            this.repo = repo;
            this.familyRepo = familyRepo;
        }

        public override async Task<int> InsertAsync(Tree entity)
        {
            if(await familyRepo.CheckExist(entity.FamilyId))
            {
                var family = await repo.GetByFamilyId(entity.FamilyId);
                if (!family.Any())
                {
                    entity.ParentId = null;
                }
                else
                {
                    if(entity.ParentId == null)
                    {
                        throw new Exception("Can't add to this family without parent");
                    }
                    else
                    {

                    }
                }
                return await base.InsertAsync(entity); 
            }
            throw new Exception($"There is no family with id = {entity.FamilyId}");
        }
    }
}
