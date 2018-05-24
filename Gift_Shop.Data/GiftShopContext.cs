using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gift_Shop.Data.Configuration;
using Gift_Shop.Entities;

namespace Gift_Shop.Data
{
    public class GiftShopContext : DbContext
    {
        public GiftShopContext() : base("GiftShopContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
        }
    }
}
