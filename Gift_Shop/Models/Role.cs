using System.Collections.Generic;

namespace Gift_Shop.Models
{
    public class Role
    {
        public int id { get; set; }
        public string role { get; set; }
        public ICollection<User> user { get; set; }
    }
}