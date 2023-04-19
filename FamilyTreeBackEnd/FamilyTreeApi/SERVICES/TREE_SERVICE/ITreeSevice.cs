using DTOs.TREE;
using ENTITIES.TREE;
using SHARED.COMMON_SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.TREE_SERVICE
{
    public interface ITreeSevice : ICommonService<Tree>
    {
        Task<SmallFamily> GetSmallFamily(int parentId);
        Task<SmallFamily> GetFirstFamily(int familyId);
    }
}
