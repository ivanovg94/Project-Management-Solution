using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjM.Models
{
    public class Team
    {

        private ICollection<Project> projects;
        private ICollection<ApplicationUser> users;

        public Team()
        {
            this.projects = new HashSet<Project>();
            this.users = new HashSet<ApplicationUser>();

        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual TeamStatus TeamStatus { get; set; }

        public virtual ICollection<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
            }
        }

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