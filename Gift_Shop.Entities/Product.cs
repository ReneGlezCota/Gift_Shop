using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gift_Shop.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagepath { get; set; }
        public float Price { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
