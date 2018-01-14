﻿using ProjM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.Views.Manage.Users
{
    public partial class UserDetails : Page
    {
        ProjMDbContext context = new ProjMDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string queryStringID = Request.QueryString["id"];
                var currentUser = context.Users.Find(queryStringID);
                UserNameL.Text = currentUser.Name;
                EmailL.Text = currentUser.Email;
                PhoneL.Text = currentUser.Phone;
                ExperienceL.Text = currentUser.Experience;
                SpecialityL.Text = currentUser.DeveloperSpeciality.Name;
                RankL.Text = currentUser.UserRank.RankName;
                RankPointsL.Text = currentUser.RankPoints.ToString();
                ProjectCountL.Text = currentUser.PastProjectCount.ToString();
                TeamL.Text = currentUser.TeamId== null ? "-" : currentUser.Team.Name;

                var langs = currentUser.ProgrammingLanguages.ToList();
                var langNames = new List<string>();
                foreach (var l in langs)
                {
                    langNames.Add(l.Name);
                }
                ProgrammingLanguagesL.Text = string.Join(", ", langNames);
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {

        }
    }
}