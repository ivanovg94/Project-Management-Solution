namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProgrammingLanguage
    {
        private ICollection<ApplicationUser> users;

        public ProgrammingLanguage()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
            }
        }
    }
}