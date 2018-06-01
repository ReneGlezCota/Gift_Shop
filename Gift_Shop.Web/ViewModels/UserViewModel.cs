using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gift_Shop.Web.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RoleID { get; set; }
    }
}