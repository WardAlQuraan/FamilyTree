using ENTITIES.TREE;
using REPOSITORIES.TREE_REPO;
using SHARED.COMMON_SERVICES;

namespace SERVICES.TREE_SERVICE
{
    public class TreeService : CommonService<Tree>, ITreeSevice
    {
        public TreeService(ITreeRepo repo) : base(repo)
        {
        }
    }
}
