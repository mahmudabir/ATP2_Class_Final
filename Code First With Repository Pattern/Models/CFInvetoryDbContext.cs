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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasKey<int>(k => k.CategoryID);

            modelBuilder.Entity<Product>()
                .HasKey<int>(k => k.ProductID);

            modelBuilder.Entity<Category>()
                .Property(p => p.CategoryName)
                .IsOptional()
                .HasColumnOrder(2);
        }
    }
}