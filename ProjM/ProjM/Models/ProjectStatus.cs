namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class ProjectStatus
    {
        private ICollection<Project> projects { get; set; }

        public ProjectStatus()
        {
            this.projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

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
    }
}