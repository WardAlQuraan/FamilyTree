using DATA_LAYER.TREE;
using ENTITIES.TREE;
using SHARED.COMMON_REPO;

namespace REPOSITORIES.TREE_REPO
{
    public class TreeRepo: CommonRepo<Tree> ,  ITreeRepo
    {
        public TreeRepo(TreeContext context) : base(context) { }
    }
}
