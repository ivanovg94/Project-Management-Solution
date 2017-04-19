namespace ProjM.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProjectCategory
    {
        private ICollection<Project> projects;

        public ProjectCategory()
        {
            this.projects = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
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