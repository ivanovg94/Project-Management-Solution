namespace ProjM.WebForms.ProjectForms
{
    using Microsoft.AspNet.Identity;
    using Models;
    using Sessions;
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Details : Page
    {
        ProjMDbContext context = new ProjMDbContext();
        Project currentProject;
        //static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //prevPage = Request.UrlReferrer.ToString();

            int queryStringID = int.Parse(Request.QueryString["id"]);
            currentProject = context.Projects.Find(queryStringID);

            MySession.Current.Data1 = Request.QueryString["id"];
            if (!IsPostBack)
            {
                if (!this.User.IsInRole("hr"))
                {
                    EditBtn.Visible = false;
                    CancelBtn.Visible = false;
                    TeamBtn.Visible = false;
                }

                if (currentProject.ProjectStatusId == 4 || currentProject.ProjectStatusId == 5)
                {
                    ParticipantsDiv.Visible = true;
                    TeamBtn.Visible = false;
                    EditBtn.Visible = false;
                    ParticipantsTb.Text = currentProject.ParticipantsList;
                    endDatePanel.Visible = true;
                    EndDateTb.Text = currentProject.EndDate;
                }

                //fill Project Type DDL
                var projectTypes = context.ProjectTypes.ToList();
                foreach (var type in projectTypes)
                {
                    PrjTypeDdl.Items.Add(new ListItem()
                    {
                        Value = type.Id.ToString(),
                        Text = type.Name
                    });
                }
                projectTypes.Clear();
                PrjTypeDdl.SelectedValue = currentProject.ProjectTypeId.ToString();

                //fill Project Category DDL
                var projectCategory = context.ProjectCategories.ToList();
                foreach (var catg in projectCategory)
                {
                    PrjCategoryDdl.Items.Add(new ListItem()
                    {
                        Value = catg.Id.ToString(),
                        Text = catg.Name
                    });
                }
                projectCategory.Clear();
                PrjCategoryDdl.SelectedValue = currentProject.ProjectCategoryId.ToString();

                StatusTb.Text = currentProject.ProjectStatus.Name;

                ProjectNameTb.Text = currentProject.Name;
                StartDateTb.Text = currentProject.StartDate == null ? "-" : currentProject.StartDate.Value.ToShortDateString();
                date.Text = currentProject.DeadLine.ToShortDateString();
                DescTextArea.Value = currentProject.Description;
                BudgetTb.Text = currentProject.Budget.ToString();
            }
        }

        protected void TeamBtn_Click(object sender, EventArgs e)
        {
            int queryStringID = int.Parse(Request.QueryString["id"]);
            var currentProject = context.Projects.Find(queryStringID);

            if (currentProject.TeamId == null)
            {
                Response.Redirect("~/Views/Manage/Teams/NewTeam.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentProject.TeamId);
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect(prevPage);


            if (User.IsInRole("hr"))
            {
                int queryStringID = int.Parse(Request.QueryString["id"]);
                var currentProject = context.Projects.Find(queryStringID);
                Response.Redirect("~/Views/Manage/Projects/All.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Users/MyProjects");
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            ProjectNameTb.Enabled = true;
            PrjTypeDdl.Enabled = true;
            PrjCategoryDdl.Enabled = true;
            DescTextArea.Disabled = false;
            BudgetTb.Enabled = true;
            date.Enabled = true;

            CancelBtn.Visible = true;
            EditBtn.Visible = false;
            SaveBtn.Visible = true;

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            ProjectNameTb.Text = currentProject.Name;
            StartDateTb.Text = currentProject.StartDate == null ? "-" : currentProject.StartDate.Value.ToShortDateString();
            date.Text = currentProject.DeadLine.ToShortDateString();
            DescTextArea.Value = currentProject.Description;
            BudgetTb.Text = currentProject.Budget.ToString();
            PrjTypeDdl.SelectedValue = currentProject.ProjectTypeId.ToString();
            PrjCategoryDdl.SelectedValue = currentProject.ProjectCategoryId.ToString();

            CancelBtn.Visible = false;
            EditBtn.Visible = true;
            SaveBtn.Visible = false;

            ProjectNameTb.Enabled = false;
            PrjTypeDdl.Enabled = false;
            PrjCategoryDdl.Enabled = false;
            DescTextArea.Disabled = true;
            BudgetTb.Enabled = false;
            date.Enabled = false;
        }
        //todo fix!!
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            currentProject.Name = ProjectNameTb.Text;
            currentProject.ProjectTypeId = int.Parse(PrjTypeDdl.SelectedValue);
            currentProject.ProjectCategoryId = int.Parse(PrjCategoryDdl.SelectedValue);
            currentProject.Description = DescTextArea.Value;
            currentProject.Budget = decimal.Parse(BudgetTb.Text);
            currentProject.DeadLine = DateTime.Parse(this.date.Text);

            context.SaveChanges();

            CancelBtn.Visible = false;
            EditBtn.Visible = true;
            SaveBtn.Visible = false;

            ProjectNameTb.Enabled = false;
            PrjTypeDdl.Enabled = false;
            PrjCategoryDdl.Enabled = false;
            DescTextArea.Disabled = true;
            BudgetTb.Enabled = false;
            date.Enabled = false;
        }
    }
}