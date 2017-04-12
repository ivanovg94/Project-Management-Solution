using ProjM.Models;
using ProjM.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.WebForms.ProjectForms
{
    public partial class Details : Page
    {
        ProjMDbContext context = new ProjMDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int queryStringID = int.Parse(Request.QueryString["id"]);
                var currentProject = context.Projects.Find(queryStringID);



                int loginId = MySession.Current.LoginId;
                string property1 = MySession.Current.Data1;
                MySession.Current.Data1 = Request.QueryString["id"];

                
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
                StatusDdl.DataSource = Enum.GetNames(typeof(ProjectStatus));
                StatusDdl.DataBind();

                StatusDdl.SelectedValue = currentProject.ProjectStatus.ToString();
                DeadLineCalendar.SelectedDate = currentProject.DeadLine.Date;
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
                Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" +currentProject.TeamId);
            }

        }
    }
}