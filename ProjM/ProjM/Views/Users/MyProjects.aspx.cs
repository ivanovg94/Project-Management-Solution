namespace ProjM.Views
{
    using Microsoft.AspNet.Identity;
    using Models;
    using ViewModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public partial class MyProjects : Page
    {
        ProjMDbContext context = new ProjMDbContext();
        string currentUserId = HttpContext.Current.User.Identity.GetUserId();

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);

            if (!IsPostBack)
            {
                if (currentUser.TeamId == null)
                {
                    noProject.Visible = true;
                }
                else
                {
                    noProject.Visible = false;
                    var currentUserTeam = context.Teams.Find(currentUser.TeamId);
                    var currentProject = context.Projects.Find(currentUserTeam.Id);

                    //invitePanel
                    if (currentUser.TeamId != null && currentUser.UserStatusId == 2)
                    {
                        ProjectNameL.Text = currentProject.Name;
                    }

                    if (currentUser.TeamId != null && currentUser.UserStatusId == 3)
                    {
                        CurrentProjNameL.Text = currentProject.Name;
                        TypeL.Text = currentProject.ProjectType.Name;
                        CategoryL.Text = currentProject.ProjectCategory.Name;
                        DescriptionL.Text = currentProject.Description;
                        StatusL.Text = currentProject.ProjectStatus.Name;
                        DeadLineL.Text = currentProject.DeadLine.ToShortDateString();
                        TeamL.Text = currentUser.Team.Name;
                        BudgetL.Text = currentProject.Budget.ToString();

                        TeamNameL.Text = currentUser.Team.Name;
                        FrontEndCount.Text = currentUserTeam.CurrentNumFrontEnd.ToString();
                        BackEndCount.Text = currentUserTeam.CurrentNumBackEnd.ToString();
                        QACount.Text = currentUserTeam.CurrentNumQA.ToString();
                        TeamStatusL.Text = currentUserTeam.TeamStatus.Name;

                        var data = context
                                .Users
                                .Where(x => x.TeamId == currentUser.TeamId)
                                .Include(x => x.DeveloperSpeciality)
                                .Include(x => x.UserRank)
                                .Include(x => x.ProgrammingLanguages)
                                .Select(x => new TeamMembersVM()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Email = x.Email,
                                    Phone = x.Phone,
                                    Specialization = x.DeveloperSpeciality.Name,
                                    //ProgrammingLanguages = string.Join(", ", context.ProgrammingLanguages.Where(r => r.Id == x.ProgrammingLanguages.FirstOrDefault().Id).Select(l => l.Name).ToList()),
                                    Rank = x.UserRank.RankName,
                                })
                                .ToList();

                        membersRept.DataSource = data;
                        membersRept.DataBind();
                    }
                }

                if (currentUser.UserStatusId == 2)
                {
                    InvitePanel.Visible = true;
                    CurrentProjectPanel.Visible = false;
                }
                else if (currentUser.UserStatusId == 3)
                {
                    CurrentProjectPanel.Visible = true;
                }
                else if (currentUser.UserStatusId == 1)
                {
                    CurrentProjectPanel.Visible = false;
                    InvitePanel.Visible = false;
                }
            }
        }

        protected void AcceptBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            currentUser.UserStatusId = 3;
            context.SaveChanges();
            InvitePanel.Visible = false;
            Response.Redirect("~/Views/Users/MyProjects");
        }

        protected void DetailsBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            var currentUserTeam = context.Teams.Find(currentUser.TeamId);
            var currentUserProject = context.Projects.Find(currentUserTeam.Id);
            Response.Redirect("~/Views/Manage/Projects/Details.aspx?id=" + currentUserProject.Id);
        }

        protected void DeclineBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            currentUser.UserStatusId = 1;

            var currentUserTeam = context.Teams.Find(currentUser.TeamId);
            switch (currentUser.DeveloperSpecialityId)
            {
                case 1: currentUserTeam.CurrentNumBackEnd--; break;
                case 2: currentUserTeam.CurrentNumFrontEnd--; break;
                case 3: currentUserTeam.CurrentNumQA--; break;
            }
            currentUser.TeamId = null;
            context.SaveChanges();
            InvitePanel.Visible = false;
            Response.Redirect("~/Views/Users/MyProjects");
        }

        protected void PrjDetailsBtn_Click(object sender, EventArgs e)
        {
            var currentUser = context.Users.Find(currentUserId);
            var currentUserTeam = context.Teams.Find(currentUser.TeamId);
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + context.Projects.Find(currentUserTeam.Id).Id);
        }
    }
}