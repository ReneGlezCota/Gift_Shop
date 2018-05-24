using System.Data.Entity.ModelConfiguration;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Categories");
            Property(a => a.Name).IsRequired().HasMaxLength(50);
        }
    }
}
