namespace ProjM.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
        private ICollection<ProgrammingLanguage> programmingLanguages;

        public string Name { get; set; }

        public ApplicationUser()
        {
            this.programmingLanguages = new HashSet<ProgrammingLanguage>();
        }

        public string Phone { get; set; }

        public int? PastProjectCount { get; set; }

        public decimal? AvrPayroll { get; set; }

        public string Experience { get; set; }

        [ForeignKey("DeveloperSpeciality")]
        public int DeveloperSpecialityId { get; set; }
        public virtual DeveloperSpeciality DeveloperSpeciality { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        [ForeignKey("UserRank")]
        public int? UserRankId { get; set; }
        public virtual UserRank UserRank { get; set; }

        [ForeignKey("UserStatus")]
        public int UserStatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }


        public virtual ICollection<ProgrammingLanguage> ProgrammingLanguages
        {
            get
            {
                return this.programmingLanguages;
            }
            set
            {
                this.programmingLanguages = value;
            }
        }

        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}