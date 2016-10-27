using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatterBugs.Startup))]
namespace ChatterBugs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
