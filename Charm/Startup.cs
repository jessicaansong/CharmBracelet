using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Charm.Startup))]
namespace Charm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
