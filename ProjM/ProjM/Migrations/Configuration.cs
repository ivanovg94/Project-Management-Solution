namespace ProjM.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ProjM.Models.ProjMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProjM.Models.ProjMDbContext";
        }

        protected override void Seed(ProjM.Models.ProjMDbContext context)
        {
            this.RolesSeeder(context);
            this.UsersSeeder(context);
        }

        private void RolesSeeder(ProjMDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleHr = new IdentityRole() { Name = "hr" };
            var roleDev = new IdentityRole() { Name = "dev" };
            var roleCandidate = new IdentityRole() { Name = "candidate" };

            if (!context.Roles.Any(role => role.Name == "hr"))
            {
                roleManager.Create(roleHr);
            }

            if (!context.Roles.Any(role => role.Name == "dev"))
            {
                roleManager.Create(roleDev);
            }

            if (!context.Roles.Any(role => role.Name == "candidate"))
            {
                roleManager.Create(roleCandidate);
            }
        }

        private void UsersSeeder(ProjMDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            if (!context.Users.Any(u => u.UserName == "hr@hr.com"))
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "hr@hr.com",
                    Email = "hr@hr.com",
                };

                userManager.Create(adminUser, "123");
                userManager.AddToRole(adminUser.Id, "hr");
            }
        }
    }
}


//  This method will be called after migrating to the latest version.

//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
//  to avoid creating duplicate seed data. E.g.
//
//    context.People.AddOrUpdate(
//      p => p.FullName,
//      new Person { FullName = "Andrew Peters" },
//      new Person { FullName = "Brice Lambson" },
//      new Person { FullName = "Rowan Miller" }
//    );
//
//    }
//}
