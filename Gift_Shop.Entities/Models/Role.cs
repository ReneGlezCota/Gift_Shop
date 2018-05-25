using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift_Shop.Entities
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
