namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DeveloperSpeciality
    {
        private ICollection<ApplicationUser> users;

        public DeveloperSpeciality()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users
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