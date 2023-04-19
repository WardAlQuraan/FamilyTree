using DTOs.TREE;
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
                        var checkExist = await repo.CheckExist((int)entity.ParentId);
                        if (!checkExist)
                        {
                            throw new Exception($"There is no Parent with id = {entity.ParentId}");
                        }
                    }
                }
                return await base.InsertAsync(entity); 
            }
            throw new Exception($"There is no family with id = {entity.FamilyId}");
        }

        public override async Task<bool> DeleteAsync(int id) 
        {
          
            var childs = await repo.GetChildrens(id);
            if (childs.Any())
            {
                throw new Exception("You must Remove Childrens of this Parent");
            }
            return await base.DeleteAsync(id);
            
        }

        public async Task<SmallFamily> GetSmallFamily(int parentId)
        {
            var checkExist = await repo.CheckExist(parentId);
            if (checkExist)
            {
                var smallFamily = new SmallFamily();
                smallFamily.Parent = await base.GetAsync(parentId);   
                smallFamily.Children = await repo.GetChildrens(parentId);
                return smallFamily;
            }
            throw new Exception($"there is no small family with id = {parentId}");
        }

        public async Task<SmallFamily> GetFirstFamily(int familyId)
        {
            var familyCheckExisit = await familyRepo.CheckExist(familyId);
            if (familyCheckExisit)
            {
                var parent =await repo.GetParentByFamilyId(familyId);
                var smallFamily = new SmallFamily();
                smallFamily.Parent = await base.GetAsync(parent.Id);
                smallFamily.Children = await repo.GetChildrens(parent.Id);
                return smallFamily;
            }
            throw new Exception($"There is no Family With Id = {familyId}");
        }
    }
}
