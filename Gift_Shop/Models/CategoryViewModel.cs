using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gift_Shop.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}