using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookShop.Client.Startup))]
namespace BookShop.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
