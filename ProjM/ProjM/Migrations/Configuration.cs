namespace ProjM.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System;

    public sealed class Configuration : DbMigrationsConfiguration<ProjM.Models.ProjMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ProjM.Models.ProjMDbContext";
        }

        protected override void Seed(ProjMDbContext context)
        {
            this.TeamStatusSeeder(context);
            this.UserStatusSeeder(context);
            this.ProjectStatusSeeder(context);
            this.UserRankSeeder(context);
            this.DeveloperSpecialitiesSeeder(context);
            this.RolesSeeder(context);
            this.UsersSeeder(context);
            this.ProgrammingLanguageSeeder(context);
            this.ProjectTypeSeeder(context);
            this.TestCategorySeeder(context);
        }

        private void TeamStatusSeeder(ProjMDbContext context)
        {
            context.TeamStatus.AddOrUpdate(new TeamStatus()
            {
                Id = 1,
                Name = "Incomplete"
            });

            context.TeamStatus.AddOrUpdate(new TeamStatus()
            {
                Id = 2,
                Name = "Pending"
            });

            context.TeamStatus.AddOrUpdate(new TeamStatus()
            {
                Id = 3,
                Name = "Active"
            });

            context.TeamStatus.AddOrUpdate(new TeamStatus()
            {
                Id = 4,
                Name = "Former"
            });
        }

        private void UserStatusSeeder(ProjMDbContext context)
        {
            context.UserStatus.AddOrUpdate(new UserStatus()
            {
                Id = 1,
                Name = "Free"
            });

            context.UserStatus.AddOrUpdate(new UserStatus()
            {
                Id = 2,
                Name = "Considering"
            });

            context.UserStatus.AddOrUpdate(new UserStatus()
            {
                Id = 3,
                Name = "Occupied"
            });
        }

        private void ProjectStatusSeeder(ProjMDbContext context)
        {
            context.ProjectStatus.AddOrUpdate(new ProjectStatus()
            {
                Id = 1,
                Name = "Not started"
            });

            context.ProjectStatus.AddOrUpdate(new ProjectStatus()
            {
                Id = 2,
                Name = "In development"
            });

            context.ProjectStatus.AddOrUpdate(new ProjectStatus()
            {
                Id = 3,
                Name = "Finished"
            });

            context.ProjectStatus.AddOrUpdate(new ProjectStatus()
            {
                Id = 4,
                Name = "Past"
            });

        }

        private void DeveloperSpecialitiesSeeder(ProjMDbContext context)
        {
            context.DeveloperSpecialities.AddOrUpdate(new DeveloperSpeciality()
            {
                Id = 4,
                Name = "None"
            });

            context.DeveloperSpecialities.AddOrUpdate(new DeveloperSpeciality()
            {
                Id = 1,
                Name = "Back-end"
            });

            context.DeveloperSpecialities.AddOrUpdate(new DeveloperSpeciality()
            {
                Id = 2,
                Name = "Front-end"
            });

            context.DeveloperSpecialities.AddOrUpdate(new DeveloperSpeciality()
            {
                Id = 3,
                Name = "QA"
            });
        }

        private void UserRankSeeder(ProjMDbContext context)
        {
            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 9,
                RankName = "None"            });

            context.UserRanks.AddOrUpdate(new UserRank()
            {
                Id = 1,
                RankName = "Candidate"            });

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
                var userHr = new ApplicationUser
                {
                    UserName = "hr@hr.com",
                    Email = "hr@hr.com",
                    DeveloperSpecialityId = 4,
                    UserRankId = 9,
                    UserStatusId = 1
                };

                userManager.Create(userHr, "123");
                userManager.AddToRole(userHr.Id, "hr");
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
