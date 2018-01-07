using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProjM.ViewModels
{
    public class ProjectVM
    {
        private DateTime deadline;
        private DateTime? startDate;

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public string Status { get; set; }

        public string Team { get; set; }

        public string TeamStatus { get; set; }

        public string Category { get; set; }

        public string Type { get; set; }

        public string DeadLine
        {
            get
            {
                return deadline.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            set { }
        }


        public DateTime DeadLineNTime
        {
            get
            {
                return this.deadline;
            }
            set
            {
                this.deadline = value;
            }
        }

        public string StartDate
        {
            get
            {
                if (startDate.HasValue)
                {
                    return startDate.Value.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return "-";
                }
            }
            set { }

        }
        public DateTime? StartDateNtime
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }
        }

    }
}