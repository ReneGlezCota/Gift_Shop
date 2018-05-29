using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gift_Shop.Web.Startup))]
namespace Gift_Shop.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
