using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjM.Models
{
    public class Project
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DeadLine { get; set; }
        public decimal? Budget { get; set; }

        public ProjectStatus ProjectStatus { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        [ForeignKey("ProjectCategory")]
        public int ProjectCategoryId { get; set; }
        public virtual ProjectCategory ProjectCategory { get; set; }

        [ForeignKey("ProjectType")]
        public int ProjectTypeId { get; set; }
        public virtual ProjectType ProjectType { get; set; }



    }
}