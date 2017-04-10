using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjM.ViewModels
{
    public class ProjectVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DeadLine { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string Team { get; set; }

        public string TeamStatus { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }
    }
}