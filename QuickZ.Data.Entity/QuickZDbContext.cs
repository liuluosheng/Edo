using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Data.Entity
{
    public class QuickZDbContext : DbContext
    {
        public QuickZDbContext() : base("name=DBEntities")
        {
            Configuration.LazyLoadingEnabled = false;
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
