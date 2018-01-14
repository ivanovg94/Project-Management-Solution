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
        private ProjMDbContext db = new ProjMDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private IQueryable<ProjectVM> GetSortedGridData(List<ProjectVM> gridData)
        {
            var filter1 = this.OrderByDdl.SelectedValue.ToString();
            var filter2 = this.DirectionDdl.SelectedValue.ToString();

            Expression<Func<ProjectVM, object>> sort = null;
            switch (filter1)
            {
                case "1": sort = x => x.Name; break;
                case "2": sort = x => x.StartDateNtime; break;
                case "3": sort = x => x.DeadLine; break;
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
                return gridData.AsQueryable().OrderByDescending(sort);
            }

            return gridData.AsQueryable().OrderBy(sort);
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

            var gridData = db.Projects.Where(searchCriteria)
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

                case "2": //not working
                    searchCriteria = x => x.StartDate.Value.ToString().Contains(enteredCriteria);
                    break;

                case "3": //not working
                    searchCriteria = x => x.DeadLine.ToString().Contains(enteredCriteria);
                    break;
                case "4": //works with x.xx, not with x,00
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