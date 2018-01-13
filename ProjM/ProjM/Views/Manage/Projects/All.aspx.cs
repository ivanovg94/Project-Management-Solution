namespace ProjM.WebForms.ProjectForms
{
    using Models;
    using ViewModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    using System.Linq.Expressions;
    using System.Web.Compilation;
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
                default:
                    break;
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

        protected void ProjectsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }

        public IQueryable<ProjectVM> ProjectsGridView_GetData()
        {
            var gridData = db.Projects
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

        }
    }
}