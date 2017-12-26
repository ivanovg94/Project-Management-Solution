namespace ProjM.WebForms.Team
{
    using Models;
    using Msg;
    using Sessions;
    using ViewModels;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;

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
                ProjectStatusValue.Text = currentProject.ProjectStatus.Name;

                //fill Team Details
                FrontEndLValue.Text = currentTeam.ReqNumFrontEnd.ToString();
                BackEndLValue.Text = currentTeam.ReqNumBackEnd.ToString();
                QALValue.Text = currentTeam.ReqNumQA.ToString();
                TotalLValue.Text = (currentTeam.ReqNumBackEnd
                                    + currentTeam.ReqNumFrontEnd
                                    + currentTeam.ReqNumQA)
                                    .ToString();
                TeamStatusValue.Text = currentTeam.TeamStatus.Name;
                //fill AllUsers Grid 
                var gridData = context
                            .Users
                            .Include(x => x.UserStatus)
                            .Include(x => x.Roles)
                            .Include(x => x.UserRank)
                            .Select(x => new DevVM()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Speciality = x.DeveloperSpeciality.Name,
                                Type = context.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name,
                                Rank = x.UserRank.RankName,
                                Status = x.UserStatus.Name
                            })
                            .ToList();
                gridData.Remove(gridData.FirstOrDefault(x => x.Type == "hr"));
                AllDevsGv.DataSource = gridData;
                AllDevsGv.DataBind();

                var statuses = currentTeam.Users.Select(x => x.UserStatusId).ToList();
                if (currentTeam.ReqNumBackEnd == currentTeam.CurrentNumBackEnd
                 && currentTeam.ReqNumFrontEnd == currentTeam.CurrentNumFrontEnd
                 && currentTeam.ReqNumQA == currentTeam.CurrentNumQA
                 && statuses.Contains(1))
                {
                    AssemblyBtn.Visible = true;
                }
                else
                {
                    AssemblyBtn.Visible = false;
                }

                //start btn
                if (statuses.Contains(2) || statuses.Contains(1) || !statuses.Any())
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
                if (currentProject.ProjectStatusId == 2)
                {
                    StartProjectBtn.Visible = false;
                    EndBtn.Visible = true;
                }
                if (currentProject.ProjectStatusId == 3)
                {
                    resultBtns.Visible = true;
                }
            }

            CurrentFrontEndLValue.Text = currentTeam.CurrentNumFrontEnd.ToString();
            CurrentBackEndLValue.Text = currentTeam.CurrentNumBackEnd.ToString();
            CurrentQALValue.Text = currentTeam.CurrentNumQA.ToString();
            CurrentTotalLValue.Text = (currentTeam.CurrentNumQA
                                        + currentTeam.CurrentNumFrontEnd
                                        + currentTeam.CurrentNumBackEnd)
                                      .ToString();

            var secondGridData = context
                           .Users
                           .Where(x => x.TeamId == queryStringID)
                           .Include(x => x.UserStatus)
                           .Include(x => x.Roles)
                           .Include(x => x.UserRank)
                           .Select(x => new DevVM()
                           {
                               Id = x.Id,
                               Name = x.Name,
                               Speciality = x.DeveloperSpeciality.Name,
                               Type = context
                                      .Roles
                                      .FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId)
                                      .Name,
                               Rank = x.UserRank.RankName,
                               Status = x.UserStatus.Name
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

                if (user.DeveloperSpecialityId == 1
                    && currentTeam.CurrentNumBackEnd < currentTeam.ReqNumBackEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumBackEnd++;
                }
                else if (user.DeveloperSpecialityId == 1
                         && currentTeam.CurrentNumBackEnd >= currentTeam.ReqNumBackEnd)
                {
                    MessageBox.Show(this, "Back-end possitions are full!");
                }

                if (user.DeveloperSpecialityId == 2
                    && currentTeam.CurrentNumFrontEnd < currentTeam.ReqNumFrontEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumFrontEnd++;
                }
                else if (user.DeveloperSpecialityId == 2
                         && currentTeam.CurrentNumFrontEnd >= currentTeam.ReqNumFrontEnd)
                {
                    MessageBox.Show(this, "Front-end possitions are full!");
                }

                if (user.DeveloperSpecialityId == 3
                    && currentTeam.CurrentNumQA < currentTeam.ReqNumQA)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumQA++;
                }
                else if (user.DeveloperSpecialityId == 3
                         && currentTeam.CurrentNumQA >= currentTeam.ReqNumQA)
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
                user.UserStatusId = 1;
                switch (user.DeveloperSpecialityId)
                {
                    case 1: currentTeam.CurrentNumBackEnd--; break;
                    case 2: currentTeam.CurrentNumFrontEnd--; break;
                    case 3: currentTeam.CurrentNumQA--; break;
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
                if (user.UserStatusId == 1)
                {
                    user.UserStatusId = 2;
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
            currentProject.ProjectStatusId = 2;
            currentProject.StartDate = DateTime.Now;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);
            currentTeam.TeamStatusId = 3;
            foreach (var user in currentTeam.Users)
            {
                user.UserStatusId = 3;
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
            currentProject.ProjectStatusId = 3;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);

            currentTeam.TeamStatusId = 4;
            EndBtn.Visible = false;

            context.SaveChanges();
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);

        }
        //todo: delete team
        protected void SuccessfulBtn_Click(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatusId = 3;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);

            var userNames = new List<string>();
            foreach (var user in currentTeam.Users)
            {
                user.PastProjectCount++;
                user.RankPoints += 10;
                if (user.RankPoints == 100 && user.UserRankId != 8)
                {
                    user.UserRankId++;
                    user.RankPoints = 0;
                }
                else if (user.RankPoints == 100 && user.UserRankId == 8)
                {
                    user.RankPoints = 100;
                }

                userNames.Add(user.Name);
                user.UserStatusId = 1;
                // user.TeamId = null;
            }
            currentProject.ProjectStatusId = 4;
            currentProject.TeamId = null;


            context.Teams.Remove(currentTeam);

            currentProject.ParticipantsList = String.Join(",", userNames);
            userNames.Clear();

            context.SaveChanges();
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + currentProjectId);
        }


        protected void FailedBtn_Click(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(MySession.Current.Data1);
            var currentProject = context.Projects.Find(currentProjectId);
            currentProject.ProjectStatusId = 3;
            int currentTeamID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(currentTeamID);

            var userNames = new List<string>();

            foreach (var user in currentTeam.Users)
            {
                //TODO:Remove teamId
                user.PastProjectCount++;
                user.RankPoints -= 10;
                if (user.RankPoints < 0)
                {
                    user.RankPoints = 0;
                }

                userNames.Add(user.Name);
                user.UserStatusId = 1;
                user.TeamId = null;
            }

            currentProject.ParticipantsList = String.Join(",", userNames);
            userNames.Clear();
            currentProject.ProjectStatusId = 4;
            currentProject.TeamId = null;
            context.Teams.Remove(currentTeam);
            context.SaveChanges();
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + currentProjectId);

        }
    }
}