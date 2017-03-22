using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjM.Models
{
    public class ProgrammingLanguage
    {

        private ICollection<ApplicationUser> users;
        public ProgrammingLanguage()
        {

            this.users = new HashSet<ApplicationUser>();
        }

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