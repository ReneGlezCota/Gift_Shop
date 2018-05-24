using System.Data.Entity.ModelConfiguration;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");
            Property(a => a.Name).IsRequired().HasMaxLength(15);
        }
    }
}
