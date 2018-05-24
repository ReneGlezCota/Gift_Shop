using System.Data.Entity.ModelConfiguration;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Products");
            Property(a => a.Name).IsRequired().HasMaxLength(50);
            Property(a => a.Price).IsRequired();
            Property(a => a.CategoryID).IsRequired();
        }
    }
}
