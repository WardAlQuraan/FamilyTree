using ENTITIES.TREE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.TREE
{
    public class TreeContext:DbContext
    {
        public TreeContext(DbContextOptions options) : base(options) { }

        public DbSet<Family> Family { get; set; }
        public DbSet<Tree> Tree { get; set; }
    }
}
