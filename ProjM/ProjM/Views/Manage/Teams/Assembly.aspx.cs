using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjM.Models;
using ProjM.Msg;
using ProjM.Sessions;
using ProjM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.WebForms.Team
{
    public partial class Assembly : System.Web.UI.Page
    {
        ProjMDbContext context = new ProjMDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            int queryStringID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(queryStringID);

            if (!IsPostBack)
            {
                //fill Project Details
                int currentProjectId = int.Parse(MySession.Current.Data1);
                var currentProject = context.Projects.Find(currentProjectId);
                ProjectNameLValue.Text = currentProject.Name;
                ProjectTypeLValue.Text = currentProject.ProjectType.Name;
                ProjectCategoryLValue.Text = currentProject.ProjectCategory.Name;
                BudgetLValue.Text = currentProject.Budget.ToString();
                ProjectStatusValue.Text = currentProject.ProjectStatus.ToString();

                //fill Team Details
                FrontEndLValue.Text = currentTeam.ReqNumFrontEnd.ToString();
                BackEndLValue.Text = currentTeam.ReqNumBackEnd.ToString();
                QALValue.Text = currentTeam.ReqNumQA.ToString();
                TotalLValue.Text = (currentTeam.ReqNumBackEnd + currentTeam.ReqNumFrontEnd + currentTeam.ReqNumQA).ToString();
                TeamStatusValue.Text = currentTeam.TeamStatus.ToString();
                //fill AllUsers Grid 
                var gridData = context
                            .Users
                            .Include(x => x.Roles)
                            .Include(x => x.UserRank)
                            .Select(x => new DevVM()
                            {
                                Id = x.Id,
                                Name = x.UserName,
                                Speciality = x.DeveloperSpec.ToString(),
                                Type = context.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name,
                                Rank = x.UserRank.RankName,
                                Status = x.UserStatus.ToString()
                            })
                            .ToList();
                gridData.Remove(gridData.FirstOrDefault(x => x.Name == "hr@hr.com"));
                AllDevsGv.DataSource = gridData;
                AllDevsGv.DataBind();

                var statuses = currentTeam.Users.Select(x => x.UserStatus).ToList();
                if (currentTeam.ReqNumBackEnd == currentTeam.CurrentNumBackEnd
                 && currentTeam.ReqNumFrontEnd == currentTeam.CurrentNumFrontEnd
                 && currentTeam.ReqNumQA == currentTeam.CurrentNumQA
                 && statuses.Contains(UserStatus.Free))
                {
                    AssemblyBtn.Visible = true;
                }
                else
                {
                    AssemblyBtn.Visible = false;
                }

                //start btn
                if (statuses.Contains(UserStatus.Considering) || statuses.Contains(UserStatus.Free) || !statuses.Any())
                {
                    StartProjectBtn.Visible = false;
                }
                else
                {
                    StartProjectBtn.Visible = true;
                }
                statuses.Clear();

                if (currentProject.StartDate != null)
                {
                    StartProjectBtn.Visible = false;
                }
                if (currentProject.ProjectStatus==ProjectStatus.InDevelopment)
                {
                    StartProjectBtn.Visible = false;
                    EndBtn.Visible = true;
                }
                if (currentProject.ProjectStatus==ProjectStatus.Finished)
                {
                    resultBtns.Visible = true;
                }
            
            }

            CurrentFrontEndLValue.Text = currentTeam.CurrentNumFrontEnd.ToString();
            CurrentBackEndLValue.Text = currentTeam.CurrentNumBackEnd.ToString();
            CurrentQALValue.Text = currentTeam.CurrentNumQA.ToString();
            CurrentTotalLValue.Text = (currentTeam.CurrentNumQA + currentTeam.CurrentNumFrontEnd + currentTeam.CurrentNumBackEnd).ToString();

            var secondGridData = context
                           .Users
                           .Where(x => x.TeamId == queryStringID)
                           .Include(x => x.Roles)
                           .Include(x => x.UserRank)
                           .Select(x => new DevVM()
                           {
                               Id = x.Id,
                               Name = x.UserName,
                               Speciality = x.DeveloperSpec.ToString(),
                               Type = context.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name,
                               Rank = x.UserRank.RankName,
                               Status = x.UserStatus.ToString()
                           })
                           .ToList();
            TeamDevsGv.DataSource = secondGridData;
            TeamDevsGv.DataBind();
        }


        //row button event
        protected void AllDevsGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            //GridView second = TeamDevsGv as GridView;
            //GridViewRow secondRow;


            if (e.CommandName == "Add")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];

                userId = row.Cells[1].Text;
                var user = context.Users.Find(userId);

                int currentTeamID = int.Parse(Request.QueryString["id"]);
                var currentTeam = context.Teams.Find(currentTeamID);

                if (user.DeveloperSpec == DeveloperSpec.Backend && currentTeam.CurrentNumBackEnd < currentTeam.ReqNumBackEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumBackEnd++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.Backend && currentTeam.CurrentNumBackEnd >= currentTeam.ReqNumBackEnd)
                {
                    MessageBox.Show(this, "Back-end possitions are full!");
                }

                if (user.DeveloperSpec == DeveloperSpec.Frontend && currentTeam.CurrentNumFrontEnd < currentTeam.ReqNumFrontEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumFrontEnd++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.Frontend && currentTeam.CurrentNumFrontEnd >= currentTeam.ReqNumFrontEnd)
                {
                    MessageBox.Show(this, "Front-end possitions are full!");
                }

                if (user.DeveloperSpec == DeveloperSpec.QA && currentTeam.CurrentNumQA < currentTeam.ReqNumQA)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumQA++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.QA && currentTeam.CurrentNumQA >= currentTeam.ReqNumQA)
                {
                    MessageBox.Show(this, "QA possitions are full!");
                }



                context.SaveChanges();

                // row.Enabled = false;



                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);
            }
        }

        //hide userId
        protected void AllDevsGv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
        }


        protected void TeamDevGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Remove")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                userId = row.Cells[1].Text;

                var user = context.Users.Find(userId);
                int currentTeamID = int.Parse(Request.QueryString["id"]);
                var currentTeam = context.Teams.Find(currentTeamID);
                user.TeamId = null;
                user.UserStatus = UserStatus.Free;
                switch (user.DeveloperSpec)
                {
                    case DeveloperSpec.Backend: currentTeam.CurrentNumBackEnd--; break;
                    case DeveloperSpec.Frontend: currentTeam.CurrentNumFrontEnd--; break;
                    case DeveloperSpec.QA: currentTeam.CurrentNumQA--; break;
                }
                context.SaveChanges();

                //enable

                //GridView first = AllDevsGv as GridView;
                //GridViewRow firstRow;
                // firstRow = first.Rows
                //    .Cast<GridViewRow>()
                //    .Where(r => r.Cells[1].Text.Equals(userId))
                //    .First();
                //firstRow.Enabled = true;

                AssemblyBtn.Visible = true;
                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);
            }
        }

        protected void TeamDevsGv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void AssemblyBtn_Click(object sender, EventArgs e)
        {
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            foreach (var user in currentTeam.Users)
            {
                if (user.UserStatus == UserStatus.Free)
                {
                    user.UserStatus = UserStatus.Considering;
                    //TODO: 
                    //send Email login here
                }
            }
            context.SaveChanges();
            AssemblyBtn.Visible = false;
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);

        }

        protected void StartProjectBtn_Click(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatus = ProjectStatus.InDevelopment;
            currentProject.StartDate = DateTime.Now;

            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            currentTeam.TeamStatus = TeamStatus.Active;
            foreach (var user in currentTeam.Users)
            {
                user.UserStatus = UserStatus.Occupied;
            }

            context.SaveChanges();
            EndBtn.Visible = true;
            StartProjectBtn.Visible = false;
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);
        }

        protected void EndBtn_Click(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatus = ProjectStatus.Finished;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            //foreach (var user in currentTeam.Users)
            //{
            //    user.PastProjectCount++;
            //    //TODO:USER PAYROLL


            //}
            currentTeam.TeamStatus = TeamStatus.Former;
            EndBtn.Visible = false;

            context.SaveChanges();
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);

        }

        protected void SuccessfulBtn_Click(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatus = ProjectStatus.Finished;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            //TODO:SET project result
            foreach (var user in currentTeam.Users)
            {
                //TODO: rank formula
                //TODO:Remove teamId
                user.PastProjectCount++;
                user.UserRank.RankPoints =+ 10;

            }
            context.SaveChanges();
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + currentProjectId);
        }

        protected void FailedBtn_Click(object sender, EventArgs e)
        {

            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatus = ProjectStatus.Finished;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            //TODO:SET project result
            foreach (var user in currentTeam.Users)
            {
                //TODO: rank formula
                //TODO:Remove teamId
                user.PastProjectCount++;
                user.UserRank.RankPoints = -10;
            }

            context.SaveChanges();
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + currentProjectId);

        }
    }
}