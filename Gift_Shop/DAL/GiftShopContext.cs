using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gift_Shop.Models;

namespace Gift_Shop.DAL
{
    public class GiftShopContext :DbContext
    {
        public GiftShopContext() : base("GiftShopContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}