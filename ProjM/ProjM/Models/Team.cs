namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {

        private ICollection<Project> projects;
        private ICollection<ApplicationUser> users;

        public Team()
        {
            this.projects = new HashSet<Project>();
            this.users = new HashSet<ApplicationUser>();

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ReqNumFrontEnd { get; set; }

        public int ReqNumBackEnd { get; set; }

        public int ReqNumQA { get; set; }

        public int? CurrentNumFrontEnd { get; set; }

        public int? CurrentNumBackEnd { get; set; }

        public int? CurrentNumQA { get; set; }

        [ForeignKey("TeamStatus")]
        public virtual int TeamStatusId { get; set; }
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