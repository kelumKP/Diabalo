using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryApp.MVC.Startup))]
namespace LibraryApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
