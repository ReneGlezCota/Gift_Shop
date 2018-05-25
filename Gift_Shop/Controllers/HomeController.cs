using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gift_Shop.Entities;
using Gift_Shop.Service;

namespace Gift_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public ActionResult Index(string category = null)
        {
            IEnumerable<Category> categories;
            categories = categoryService.GetCategories(category).ToList();
            return View();
        }        
    }
}