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
            this.ProgrammingLanguageSeeder(context);
            this.ProjectTypeSeeder(context);
            this.TestCategorySeeder(context);
            this.UserRankSeeder(context);
        }

        private void UserRankSeeder(ProjMDbContext context)
        {
            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 0,
                RankName = "None",
                RankPoints = 0
            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 1,
                RankName = "Candidate",
                RankPoints = 0
            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 2,
                RankName = "Novice",

            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 3,
                RankName = "Begginer",
              
            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 4,
                RankName = "Intermediate",

            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 5,
                RankName = "Adept",

            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 6,
                RankName = "Seasoned",

            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 7,
                RankName = "Senior",

            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 8,
                RankName = "Expert",

            });




        }

        private void TestCategorySeeder(ProjMDbContext context)
        {
            context.ProjectCategories.AddOrUpdate(new ProjectCategory()
            {
                Id = 1,
                Name = "First Test Category"
            });

            context.ProjectCategories.AddOrUpdate(new ProjectCategory()
            {
                Id = 2,
                Name = "Second Test Category"
            });
        }

        private void ProjectTypeSeeder(ProjMDbContext context)
        {
            context.ProjectTypes.AddOrUpdate(new ProjectType()
            {
                Id = 1,
                Name = "Desktop Application"
            });

            context.ProjectTypes.AddOrUpdate(new ProjectType()
            {
                Id = 2,
                Name = "Web Application"
            });

            context.ProjectTypes.AddOrUpdate(new ProjectType()
            {
                Id = 3,
                Name = "Mobile Application"
            });
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
                    DeveloperSpec = DeveloperSpec.None,
                    UserRankId = 0
                };

                userManager.Create(adminUser, "123");
                userManager.AddToRole(adminUser.Id, "hr");
            }
        }

        private void ProgrammingLanguageSeeder(ProjMDbContext context)
        {
            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 1,
                Name = "Java"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 2,
                Name = "Python"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 3,
                Name = "C"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 4,
                Name = "C#"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 5,
                Name = "C++"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 6,
                Name = "Objective-C"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 7,
                Name = "GO"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 8,
                Name = "Swift"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 9,
                Name = "Ruby"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 10,
                Name = "Java Script"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 11,
                Name = "PHP"
            });

            context.ProgrammingLanguages.AddOrUpdate(new ProgrammingLanguage()
            {
                Id = 12,
                Name = "SQL"
            });

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
