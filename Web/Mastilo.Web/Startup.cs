using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mastilo.Web.Startup))]
namespace Mastilo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
