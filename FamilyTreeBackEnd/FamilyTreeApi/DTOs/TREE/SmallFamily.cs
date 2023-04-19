using ENTITIES.TREE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.TREE
{
    public class SmallFamily
    {
        public Tree Parent { get; set; }

        public List<Tree> Children { get; set; }
    }
}
