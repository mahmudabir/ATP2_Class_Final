using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Code_First_With_Repository_Pattern.Models
{
    public class CFInvetoryDbContext : DbContext
    {
        public CFInvetoryDbContext() : base("CFInventoryDb")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists);
            //Database.SetInitializer(new DropCreateDatabaseAlways);
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CFInvetoryDbContext>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}