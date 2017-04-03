﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjM.Models
{
    public class UserRank
    {
        private ICollection<ApplicationUser> users;

        public UserRank()
        {
            this.users = new HashSet<ApplicationUser>();

        }

        public int Id { get; set; }

        public string RankName { get; set; }

        public int? RankPoints { get; set; }

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