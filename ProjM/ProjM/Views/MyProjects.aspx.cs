using Microsoft.AspNet.Identity;
using ProjM.Models;
using ProjM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.Views
{
    public partial class MyProjects : System.Web.UI.Page
    {
        ProjMDbContext context = new ProjMDbContext();
        string currentUserId = HttpContext.Current.User.Identity.GetUserId();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);

            if (!IsPostBack)
            {
                var currentUserTeam = context.Teams.Find(currentUser.TeamId);
                if (currentUser.TeamId != null && currentUser.UserStatus == UserStatus.Considering)
                {
                    var currentUserProject = context.Projects.FirstOrDefault(p => p.TeamId == currentUserTeam.Id);
                    ProjectNameL.Text = currentUserProject.Name;
                }

                if (currentUser.TeamId != null && currentUser.UserStatus == UserStatus.Occupied)
                {
                    var currentProject = context.Projects.FirstOrDefault(p => p.TeamId == currentUserTeam.Id);
                    CurrentProjNameL.Text = currentProject.Name;
                    TypeL.Text = currentProject.ProjectType.Name;
                    CategoryL.Text = currentProject.ProjectCategory.Name;
                    DescriptionL.Text = currentProject.Description;
                    StatusL.Text = currentProject.ProjectStatus.ToString();
                    DeadLineL.Text = currentProject.DeadLine.ToShortDateString();
                    TeamL.Text = currentProject.Team.Name;
                    BudgetL.Text = currentProject.Budget.ToString();

                    TeamNameL.Text = currentUser.Team.Name;
                    FrontEndCount.Text = currentUserTeam.CurrentNumFrontEnd.ToString();
                    BackEndCount.Text = currentUserTeam.CurrentNumBackEnd.ToString();
                    QACount.Text = currentUserTeam.CurrentNumQA.ToString();

                    var data = context
                            .Users
                            .Where(x => x.TeamId == currentUser.TeamId)
                            .Include(x => x.DeveloperSpec)
                            .Include(x => x.UserRank)
                            .Include(x => x.ProgrammingLanguages)
                            .Select(x => new TeamMembersVM()
                            {
                                Id = x.Id,
                                Name = x.UserName,
                                Email = x.Email,
                                Phone = x.Phone,
                                Specialization = x.DeveloperSpec.ToString(),
                                //ProgrammingLanguages = string.Join(", ", context.ProgrammingLanguages.Where(r => r.Id == x.ProgrammingLanguages.FirstOrDefault().Id).Select(l => l.Name).ToList()),
                                Rank = x.UserRank.RankName,
                            })
                            .ToList();


                    membersRept.DataSource = data;
                    membersRept.DataBind();


                }
            }



            if (currentUser.UserStatus == UserStatus.Considering)
            {
                InvitePanel.Visible = true;
                CurrentProjectPanel.Visible = false;
            }
            else if (currentUser.UserStatus == UserStatus.Occupied)
            {
                CurrentProjectPanel.Visible = true;
            }
            else if (currentUser.UserStatus == UserStatus.Free)
            {
                CurrentProjectPanel.Visible = false;
                InvitePanel.Visible = false;

            }


        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            currentUser.UserStatus = UserStatus.Occupied;
            context.SaveChanges();
            InvitePanel.Visible = false;
            Response.Redirect("~/Views/MyProjects");

        }

        protected void DetailsBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            var currentUserTeam = context.Teams.Find(currentUser.TeamId);
            var currentUserProject = context.Projects.FirstOrDefault(p => p.TeamId == currentUserTeam.Id);

            //TODO: REPLACE
            Response.Redirect("~/Views/Manage/Projects/Details.aspx?id=" + currentUserProject);



        }

        protected void DeclineBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            currentUser.UserStatus = UserStatus.Free;

            var currentUserTeam = context.Teams.Find(currentUser.TeamId);
            switch (currentUser.DeveloperSpec)
            {
                case DeveloperSpec.Backend: currentUserTeam.CurrentNumBackEnd--; break;
                case DeveloperSpec.Frontend: currentUserTeam.CurrentNumFrontEnd--; break;
                case DeveloperSpec.QA: currentUserTeam.CurrentNumQA--; break;
            }
            currentUser.TeamId = null;

            context.SaveChanges();
            InvitePanel.Visible = false;
            Response.Redirect("~/Views/MyProjects");

        }
    }
}