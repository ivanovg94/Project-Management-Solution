namespace ProjM.WebForms.ProjectForms
{
    using Models;
    using ViewModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI.WebControls;
    public partial class All : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjMDbContext db = new ProjMDbContext();

                var gridData = db.Projects
                      .Include(x => x.ProjectCategory)
                      .Include(x => x.ProjectStatus)
                      .Include(x => x.ProjectType)
                      .Include(x => x.Team)
                      .Select(x => new ProjectVM()
                      {
                          Id = x.Id,
                          Name = x.Name,
                          DeadLine = x.DeadLine,
                          Budget = x.Budget,
                          Status = x.ProjectStatus.Name,
                          Team = x.Team == null ? "-" : x.Team.Name,
                          TeamStatus = x.Team == null ? "-" : x.Team.TeamStatus.Name,
                          Category = x.ProjectCategory.Name,
                          Type = x.ProjectType.Name
                      })
                      .ToList();

                ProjectsGridView.DataSource = gridData;
                ProjectsGridView.DataBind();
            }
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
            }
            Response.Redirect("~/Views/Manage/Projects/Details.aspx?id=" + id.ToString());
        }
    }
}