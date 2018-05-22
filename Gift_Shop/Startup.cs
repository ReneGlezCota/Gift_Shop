using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gift_Shop.Startup))]
namespace Gift_Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
