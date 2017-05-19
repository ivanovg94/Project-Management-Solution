using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjM.Models
{
    public class UserStatus
    {
        private ICollection<ApplicationUser> users { get; set; }

        public UserStatus()
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
