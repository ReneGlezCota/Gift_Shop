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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var roles = new List<Role>
            {
                new Role { id=1, role="Admin"},
                new Role { id=2, role="Registered"},
                new Role { id=3, role="Unregistered"}
            };

            roles.ForEach(a => context.Roles.AddOrUpdate(a));
            context.SaveChanges();

            var user = new User { id = 1, username = "testAdmin", password = "123", roleid = roles.Single(s=>s.role == "Admin").id, firstname = "Test", lastname = "Test" };
            context.Users.AddOrUpdate(user);
            context.SaveChanges();

        }
    }
}
