using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gift_Shop.Models;

namespace Gift_Shop.DAL
{
    public class GiftShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GiftShopContext>
    {

        protected override void Seed(GiftShopContext context)
        {
            var roles = new List<Role>
            {
                new Role { id=1, role="Admin"},
                new Role { id=2, role="Registered"},
                new Role { id=3, role="Unregistered"}
            };

            roles.ForEach(a => context.Roles.Add(a));
            context.SaveChanges();
        }   
    }
}