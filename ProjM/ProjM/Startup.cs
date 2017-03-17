using Microsoft.Owin;
using Owin;
using ProjM.Migrations;
using ProjM.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(ProjM.Startup))]
namespace ProjM
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ProjMDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
