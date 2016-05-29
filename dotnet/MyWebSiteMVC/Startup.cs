using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWebSiteMVC.Startup))]
namespace MyWebSiteMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
