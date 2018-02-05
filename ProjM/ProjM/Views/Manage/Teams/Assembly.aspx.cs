namespace ProjM.WebForms.Team
{
    using Models;
    using Sessions;
    using ViewModels;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public partial class Assembly : System.Web.UI.Page
    {
        ProjMDbContext context = new ProjMDbContext();
        int queryStringID = -1;
        int currentProjectId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryStringID = int.Parse(Request.QueryString["id"]);
            var currentTeam = context.Teams.Find(queryStringID);

            if (!IsPostBack)
            {
                //fill Project Details
                currentProjectId = int.Parse(MySession.Current.Data1);
                var currentProject = context.Projects.Find(currentProjectId);
                ProjectNameLValue.Text = currentProject.Name;
                ProjectTypeLValue.Text = currentProject.ProjectType.Name;
                ProjectCategoryLValue.Text = currentProject.ProjectCategory.Name;
                BudgetLValue.Text = currentProject.Budget.ToString();
                ProjectStatusValue.Text = currentProject.ProjectStatus.Name;

                //fill Team Details  
                TeamNameL.Text = currentTeam.Name;
                FrontEndLValue.Text = currentTeam.ReqNumFrontEnd.ToString();
                BackEndLValue.Text = currentTeam.ReqNumBackEnd.ToString();
                QALValue.Text = currentTeam.ReqNumQA.ToString();
                TotalLValue.Text = (currentTeam.ReqNumBackEnd
                                    + currentTeam.ReqNumFrontEnd
                                    + currentTeam.ReqNumQA)
                                    .ToString();
                TeamStatusValue.Text = currentTeam.TeamStatus.Name;


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
        }

        //row button event
        protected void AllDevsGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Add")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];

                userId = row.Cells[0].Text;
                var user = context.Users.Find(userId);

                int currentTeamID = int.Parse(Request.QueryString["id"]);
                var currentTeam = context.Teams.Find(currentTeamID);

                if (user.DeveloperSpecialityId == 1
                    && currentTeam.CurrentNumBackEnd < currentTeam.ReqNumBackEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumBackEnd++;
                }
                //else if (user.DeveloperSpecialityId == 1
                //         && currentTeam.CurrentNumBackEnd >= currentTeam.ReqNumBackEnd)
                //{
                //    MessageBox.Show(this, "Back-end possitions are full!");
                //}

                if (user.DeveloperSpecialityId == 2
                    && currentTeam.CurrentNumFrontEnd < currentTeam.ReqNumFrontEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumFrontEnd++;
                }
                //else if (user.DeveloperSpecialityId == 2
                //         && currentTeam.CurrentNumFrontEnd >= currentTeam.ReqNumFrontEnd)
                //{
                //    MessageBox.Show(this, "Front-end possitions are full!");
                //}

                if (user.DeveloperSpecialityId == 3
                    && currentTeam.CurrentNumQA < currentTeam.ReqNumQA)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumQA++;
                }
                //else if (user.DeveloperSpecialityId == 3
                //         && currentTeam.CurrentNumQA >= currentTeam.ReqNumQA)
                //{
                //    MessageBox.Show(this, "QA possitions are full!");
                //}

                context.SaveChanges();

                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);
            }
            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                userId = row.Cells[0].Text;
                Response.Redirect("~/Views/Users/UserDetails.aspx?id=" + userId);
            }
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
                userId = row.Cells[0].Text;
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

                AssemblyBtn.Visible = true;
                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);
            }
            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                userId = row.Cells[0].Text;
                Response.Redirect("~/Views/Users/UserDetails.aspx?id=" + userId);
            }
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
            currentProject.StartDate = DateTime.Now.Date;
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
            currentProject.EndDate = DateTime.Now.ToShortDateString();
            context.SaveChanges();
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamID);

        }

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
                user.LastProjectInfo = string.Format("Project name: {0}, End date: {1}, Result: Successful", currentProject.Name, currentProject.EndDate);
                user.PastProjectCount++;
                user.RankPoints += 10;
                if (user.UserRankId==1)
                {
                    user.UserRankId++; ;
                }
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
            }

            currentProject.ProjectStatusId = 5;
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
                user.LastProjectInfo = string.Format("Project name: {0}, End date: {1}, Result: Unsuccessful", currentProject.Name, currentProject.EndDate);
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

            currentProject.ParticipantsList = String.Join(", ", userNames);
            userNames.Clear();
            currentProject.ProjectStatusId = 4;
            currentProject.TeamId = null;
            context.Teams.Remove(currentTeam);
            context.SaveChanges();
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + currentProjectId);
        }

        public IQueryable<DevVM> AllDevsGv_GetData()
        {
            var filter1 = this.OrderByDdl.SelectedValue.ToString();
            var filter2 = this.DirectionDdl.SelectedValue.ToString();

            Expression<Func<ApplicationUser, bool>> searchCriteria = this.GetSearchCriteria();

            var gridData = context
                          .Users.Where(searchCriteria)
                          .Include(x => x.UserStatus)
                          .Include(x => x.Roles)
                          .Include(x => x.UserRank)
                          .Where(x => x.UserStatusId == 1
                                        && x.Roles.FirstOrDefault().RoleId
                                        != context.Roles.FirstOrDefault(r => r.Name == "hr").Id)
                          .Select(x => new DevVM()
                          {
                              Id = x.Id,
                              Name = x.Name,
                              Speciality = x.DeveloperSpeciality.Name,
                              Rank = x.UserRank.RankName,
                              ProjectCount = x.PastProjectCount,
                              RankId = x.UserRankId,
                              Status = x.UserStatus.Name
                          });

            Expression<Func<DevVM, object>> sort = null;
            switch (filter1)
            {
                case "1": sort = x => x.Name; break;
                case "2": sort = x => x.Speciality; break;
                case "3": sort = x => x.RankId.ToString(); break;
                case "4": sort = x => x.ProjectCount.ToString(); break;
            }

            if (filter2 == "2")
            {
                return gridData.OrderByDescending(sort);
            }

            return gridData.OrderBy(sort);
        }

        public IQueryable<DevVM> TeamDevsGv_GetData()
        {
            var teamMembersGV = context
                                .Users
                                .Include(x => x.UserStatus)
                                .Include(x => x.Roles)
                                .Include(x => x.UserRank)
                                .Where(x => x.TeamId == queryStringID)
                                .Select(x => new DevVM()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Speciality = x.DeveloperSpeciality.Name,
                                    Rank = x.UserRank.RankName,
                                    Status = x.UserStatus.Name
                                });

            return teamMembersGV;
        }

        protected void SortBtn_Click(object sender, EventArgs e)
        {
            AllDevsGv.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Expression<Func<ApplicationUser, bool>> searchCriteria = this.GetSearchCriteria();
            this.AllDevsGv.DataBind();
        }

        private Expression<Func<ApplicationUser, bool>> GetSearchCriteria()
        {

            Expression<Func<ApplicationUser, bool>> searchCriteria = (ApplicationUser user) => true;

            var enteredCriteria = this.SearchKeyWord.Text;

            var selectedValue = this.SearchByDdl.SelectedValue;
            switch (selectedValue)
            {
                case "1":
                    searchCriteria = x => x.Name.Contains(enteredCriteria);
                    break;

                case "2":
                    searchCriteria = x => x.DeveloperSpeciality.Name.Contains(enteredCriteria);
                    break;
                case "3":
                    searchCriteria = x => x.UserRank.RankName.Contains(enteredCriteria);
                    break;
                case "4":
                    searchCriteria = x => x.PastProjectCount.ToString().Contains(enteredCriteria);
                    break;
                default:
                    break;
            }
            return searchCriteria;
        }

        protected void PrjDetailsBtn_Click(object sender, EventArgs e)
        {
            queryStringID = int.Parse(Request.QueryString["id"]);
            Response.Redirect("/Views/Manage/Projects/Details.aspx?id=" + queryStringID);
        }
    }
}