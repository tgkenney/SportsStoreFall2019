using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsStoreFall2019.Startup))]
namespace SportsStoreFall2019
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
