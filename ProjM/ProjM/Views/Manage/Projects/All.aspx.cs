namespace ProjM.WebForms.ProjectForms
{
    using Models;
    using ViewModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    public partial class All : System.Web.UI.Page
    {
        private ProjMDbContext context = new ProjMDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            foreach (var project in context.Projects.ToList())
            {
                if (project.DeadLine < DateTime.Now)
                {
                    project.ProjectStatusId = 3;
                    var currentTeam = project.Team;

                    if (currentTeam != null)
                    {
                        var userNames = new List<string>();

                        foreach (var user in currentTeam.Users)
                        {
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
                        project.ParticipantsList = String.Join(",", userNames);
                        userNames.Clear();
                        project.TeamId = null;
                        context.Teams.Remove(currentTeam);
                    }
                    project.ProjectStatusId = 4;
                    context.SaveChanges();

                }

            }
        }

        private IQueryable<ProjectVM> GetSortedGridData(List<ProjectVM> gridData)
        {
            var data = gridData.AsQueryable();

            var filter1 = this.OrderByDdl.SelectedValue.ToString();
            var filter2 = this.DirectionDdl.SelectedValue.ToString();

            Expression<Func<ProjectVM, object>> sort = null;
            switch (filter1)
            {
                case "1": sort = x => x.Name; break;
                case "2":
                    sort = x => x.StartDateNtime;
                    break;
                case "3":
                    sort = x => DateTime.Parse(x.DeadLine);
                    break;
                case "4": sort = x => x.Budget; break;
                case "5": sort = x => x.StatusId; break;
                case "6": sort = x => x.Team; break;
                case "7": sort = x => x.TeamStatusId; break;
                case "8": sort = x => x.Category; break;
                case "9": sort = x => x.Type; break;
                default: sort = x => x.Name; break;
            }

            if (filter2 == "2")
            {
                return data.OrderByDescending(sort);
            }

            return data.OrderBy(sort);
        }


        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            int id = -1;
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Details")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                id = int.Parse(row.Cells[0].Text);
                Response.Redirect("~/Views/Manage/Projects/Details.aspx?id=" + id.ToString());
            }
        }

        public IQueryable<ProjectVM> ProjectsGridView_GetData()
        {
            Expression<Func<Project, bool>> searchCriteria = this.GetSearchCriteria();

            var gridData = context.Projects.Where(searchCriteria)
                        .Include(x => x.ProjectCategory)
                        .Include(x => x.ProjectStatus)
                        .Include(x => x.ProjectType)
                        .Include(x => x.Team)
                 .Select(x => new ProjectVM()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     DeadLineNTime = x.DeadLine,
                     StartDateNtime = x.StartDate,
                     Budget = x.Budget,
                     Status = x.ProjectStatus.Name,
                     StatusId = x.ProjectStatusId,
                     Team = x.Team == null ? "-" : x.Team.Name,
                     TeamStatus = x.Team == null ? "-" : x.Team.TeamStatus.Name,
                     TeamStatusId = x.Team == null ? 0 : x.Team.TeamStatusId,
                     Category = x.ProjectCategory.Name,
                     Type = x.ProjectType.Name
                 }).ToList();

            var sortedGridData = this.GetSortedGridData(gridData);

            return sortedGridData;
        }

        protected void SortBtn_Click(object sender, EventArgs e)
        {
            this.ProjectsGridView.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            Expression<Func<Project, bool>> searchCriteria = this.GetSearchCriteria();
            this.ProjectsGridView.DataBind();
        }

        private Expression<Func<Project, bool>> GetSearchCriteria()
        {

            Expression<Func<Project, bool>> searchCriteria = (Project project) => true;

            var enteredCriteria = this.SearchKeyWord.Text;

            var selectedValue = this.SearchByDdl.SelectedValue;
            switch (selectedValue)
            {
                case "1":
                    searchCriteria = x => x.Name.Contains(enteredCriteria);
                    break;

                case "2":

                    DateTime dateTime2;
                    if (DateTime.TryParse(enteredCriteria, out dateTime2))
                    {
                        var date = DateTime.Parse(enteredCriteria);
                        searchCriteria = x => x.StartDate.Value == dateTime2;
                    }
                    else
                    {
                        searchCriteria = x => !x.StartDate.HasValue;
                    }
                    break;

                case "3":
                    searchCriteria = x => x.DeadLine == DateTime.Parse(enteredCriteria);
                    break;
                case "4":
                    searchCriteria = x => x.Budget.ToString().Contains(enteredCriteria);
                    break;
                case "5":
                    searchCriteria = x => x.ProjectStatus.Name.Contains(enteredCriteria);
                    break;
                case "6":
                    searchCriteria = x => x.Team.Name.Contains(enteredCriteria);
                    break;
                case "7":
                    searchCriteria = x => x.Team.TeamStatus.Name.Contains(enteredCriteria);
                    break;
                case "8":
                    searchCriteria = x => x.ProjectCategory.Name.Contains(enteredCriteria);
                    break;
                case "9":
                    searchCriteria = x => x.ProjectType.Name.Contains(enteredCriteria);
                    break;

                default:
                    break;
            }

            return searchCriteria;
        }
    }
}