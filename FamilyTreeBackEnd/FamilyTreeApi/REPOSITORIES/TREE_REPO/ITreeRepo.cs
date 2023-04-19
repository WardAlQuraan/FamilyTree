using ENTITIES.TREE;
using SHARED.COMMON_REPO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPOSITORIES.TREE_REPO
{
    public interface ITreeRepo : ICommonRepo<Tree>
    {
        Task<List<Tree>> GetByFamilyId(int familyId);
    }
}
