using ENTITIES.CORE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA_LAYER.CORE
{
    public class CoreContext:DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options) { }
        
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
