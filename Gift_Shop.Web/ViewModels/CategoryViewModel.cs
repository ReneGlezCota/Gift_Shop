using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gift_Shop.Web.ViewModels;

namespace Gift_Shop.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}