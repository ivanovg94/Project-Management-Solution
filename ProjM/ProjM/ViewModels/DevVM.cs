using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjM.ViewModels
{
    public class DevVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Rank { get; set; }

        public string Speciality { get; set; }

        public string Status { get; set; }
        public int RankId { get; internal set; }
        public int ProjectCount { get; internal set; }
    }
}