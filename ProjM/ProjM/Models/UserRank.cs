namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class UserRank
    {
        private ICollection<ApplicationUser> users;

        public UserRank()
        {
            this.users = new HashSet<ApplicationUser>();

        }

        [Key]
        public int Id { get; set; }

        public string RankName { get; set; }

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