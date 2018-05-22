using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gift_Shop.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public int roleid { get; set; }
        public virtual Role role { get; set; }
    }
}