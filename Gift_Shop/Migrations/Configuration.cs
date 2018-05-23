namespace Gift_Shop.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Gift_Shop.DAL.GiftShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gift_Shop.DAL.GiftShopContext context)
        {
            var roles = new List<Role>
            {
                new Role { id=1, role="Admin"},
                new Role { id=2, role="Registered"},
                new Role { id=3, role="Unregistered"}
            };

            roles.ForEach(a => context.Roles.AddOrUpdate(a));
            context.SaveChanges();

            var user = new User { id = 1, username = "testAdmin", password = "123", roleid = roles.Single(s => s.role == "Admin").id, firstname = "Test", lastname = "Test" };
            context.Users.AddOrUpdate(user);
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category { id = 1, category = "Computers" },
                new Category { id = 2, category = "Electronics" },
                new Category { id = 3, category = "Sports" },
                new Category { id = 4, category = "Cell Phones"}
            };

            categories.ForEach(a => context.Categories.AddOrUpdate(a));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { id = 1, name = "Dell Latitude E7440", price = 13000, description = "Full HD Touchscreen display and a beautiful design. The thin (21 mm) Latitude 14 has a starting weight of just 3.7 lb with a 4-cell battery and comes standard with sleek, durable aluminum, soft-touch finishes and a powder-coated base", categoryID = categories.Single(a=>a.category == "Computers").id, imagepath = ""  },
                new Product { id = 2, name = "JBL Flip 4", price = 2000, description = "JBL Flip 4 is the next generation in the award-winning Flip series; it is a portable Bluetooth speaker that delivers surprisingly powerful stereo sound. This compact speaker is powered by a 3000mAh rechargeable Li-ion battery that offers 12 hours of continuous, high-quality audio playtime", categoryID = categories.Single(a=>a.category == "Electronics").id, imagepath = ""  },
                new Product { id = 3, name = "Wilson A360 Baseball Glove", price = 1500, description = "The 10 A360 is the perfect glove for those just learning the game. Its 10 utility size allows the young ballplayer to play anywhere on the field, helping develop their game. The A360 will go a long way in the development of young ball players", categoryID = categories.Single(a=>a.category == "Sports").id, imagepath = ""  },
                new Product { id = 4, name = "Samsung Galaxy S9", price = 16000, description = "Introducing the revolutionary Galaxy S9. The phone that reimagines the camera. And in doing so reimagines everything you can do, too.", categoryID = categories.Single(a=>a.category == "Cell Phones").id, imagepath = ""  }

            };

            products.ForEach(a => context.Products.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
