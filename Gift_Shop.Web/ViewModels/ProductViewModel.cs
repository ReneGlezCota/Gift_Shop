using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gift_Shop.Web.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ImagePath { get; set; }

        public int CategoryID { get; set; }
    }
}