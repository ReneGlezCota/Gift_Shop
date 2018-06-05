﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gift_Shop.Web.ViewModels
{
    public class ProductFormViewModel
    {
        public string ProductFile { get; set; }        
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCategory { get; set; }
    }
}