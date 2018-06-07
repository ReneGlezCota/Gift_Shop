using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gift_Shop.Entities;

namespace Gift_Shop.Data
{
    public class GiftShopInitializer : DropCreateDatabaseIfModelChanges<GiftShopContext>
    {
        protected override void Seed(GiftShopContext context)
        {
            GetRoles().ForEach(a => context.Roles.Add(a));
            GetUsers().ForEach(a => context.Users.Add(a));
            GetCategories().ForEach(a => context.Categories.Add(a));
            GetProducts().ForEach(a => context.Products.Add(a));

            context.Commit();
        }

        private static List<Role> GetRoles()
        {
            return new List<Role> {
                new Role { Name = "Admin" },
                new Role { Name = "Registered" },
                new Role { Name = "Unregistered" }
            };
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User { UserName = "Admin", Password = "123", RoleID = 1, FirstName = "Test", LastName = "Test" },
                new User { UserName = "Admin2", Password = "321", RoleID = 2, FirstName = "Test2", LastName = "Test2" }
            };
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Computers" },
                new Category { Name = "Electronics" },
                new Category { Name = "Sports" },
                new Category { Name = "Cell Phones"}
            };
        }

        private static List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product { Name = "Dell Latitude E7440", Price = 13000, Description = "Full HD Touchscreen display and a beautiful design. The thin (21 mm) Latitude 14 has a starting weight of just 3.7 lb with a 4-cell battery and comes standard with sleek, durable aluminum, soft-touch finishes and a powder-coated base", CategoryID = 1, Imagepath = "default.jpg"  },
                new Product { Name = "JBL Flip 4", Price = 2000, Description = "JBL Flip 4 is the next generation in the award-winning Flip series; it is a portable Bluetooth speaker that delivers surprisingly powerful stereo sound. This compact speaker is powered by a 3000mAh rechargeable Li-ion battery that offers 12 hours of continuous, high-quality audio playtime", CategoryID = 2, Imagepath = "default.jpg"  },
                new Product { Name = "Wilson A360 Baseball Glove", Price = 1500, Description = "The 10 A360 is the perfect glove for those just learning the game. Its 10 utility size allows the young ballplayer to play anywhere on the field, helping develop their game. The A360 will go a long way in the development of young ball players", CategoryID=3, Imagepath = "default.jpg"  },
                new Product { Name = "Samsung Galaxy S9", Price = 16000, Description = "Introducing the revolutionary Galaxy S9. The phone that reimagines the camera. And in doing so reimagines everything you can do, too.", CategoryID = 4, Imagepath = "default.jpg"  }                
            };
        }
    }
}
