using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjM.Startup))]
namespace ProjM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
