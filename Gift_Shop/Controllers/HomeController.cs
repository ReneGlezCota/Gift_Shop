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
        public ActionResult Index()
        {            
            return View();
        }        
    }
}