using DATA_LAYER.TREE;
using ENTITIES.TREE;
using Microsoft.EntityFrameworkCore;
using SHARED.COMMON_REPO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPOSITORIES.TREE_REPO
{
    public class TreeRepo: CommonRepo<Tree> ,  ITreeRepo
    {
        private readonly TreeContext context;
        public TreeRepo(TreeContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<List<Tree>> GetByFamilyId(int familyId)
        {
            var family = await context.Tree.Where(x => x.FamilyId == familyId).ToListAsync();
            return family;
        }
    }
}
