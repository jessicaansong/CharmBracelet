using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewPortfolio.Startup))]
namespace NewPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
