using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Gift_Shop.Models;

namespace Gift_Shop.DAL
{
    public class GiftShopContext :DbContext
    {
        public GiftShopContext() : base("GiftShopContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}