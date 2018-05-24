using System.Data.Entity.ModelConfiguration;
using Gift_Shop.Entities;

namespace Gift_Shop.Data.Configuration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            Property(a => a.UserName).IsRequired();
            Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            Property(a => a.LastName).IsRequired().HasMaxLength(100);
            Property(a => a.RoleID).IsRequired();
        }
    }
}
