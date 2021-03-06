﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gift_Shop.App_Start;
using Gift_Shop.Data;

namespace Gift_Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Init DataBase()
            System.Data.Entity.Database.SetInitializer(new GiftShopInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
