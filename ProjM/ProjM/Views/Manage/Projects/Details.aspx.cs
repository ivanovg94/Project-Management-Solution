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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int queryStringID = int.Parse(Request.QueryString["id"]);
                var currentProject = context.Projects.Find(queryStringID);

                int loginId = MySession.Current.LoginId;    //?
                string property1 = MySession.Current.Data1; //?

                MySession.Current.Data1 = Request.QueryString["id"];

           //     ApplicationUser currentUser = context.Users.FirstOrDefault(x => x.Id == User.Identity.GetUserId());
                
             //   var currentUserRoleName = context.Roles.FirstOrDefault(r => r.Id == currentUser.Roles.FirstOrDefault().RoleId).Name;
                if (!this.User.IsInRole("hr"))
                {
                    EditBtn.Visible = false;
                    CancelBtn.Visible = false;
                    TeamBtn.Visible = false;
                    BackBtn.Visible = true;
                }

                if (currentProject.ProjectStatusId == 4)
                {
                    ParticipantsDiv.Visible = true;
                    TeamBtn.Visible = false;
                    ParticipantsTb.Text = currentProject.ParticipantsList;
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

                //fill ProjectStatus DDL
                var projectStatus = context.ProjectStatus.ToList();
                foreach (var status in projectStatus)
                {
                    StatusDdl.Items.Add(new ListItem()
                    {
                        Value = status.Id.ToString(),
                        Text = status.Name
                    });
                }
                projectStatus.Clear();
                StatusDdl.SelectedValue = currentProject.ProjectStatusId.ToString();

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
            int queryStringID = int.Parse(Request.QueryString["id"]);
            var currentProject = context.Projects.Find(queryStringID);
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentProject.TeamId);
        }
    }
}