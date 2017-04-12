using ProjM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.ProjectForms
{
    public partial class NewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new ProjMDbContext();

            if (!IsPostBack)
            {
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
            }
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            var context = new ProjMDbContext();

            Project project = new Project(); 

            project.Name = ProjectNameTb.Text;
            project.Description = DescTextArea.Value;
            project.DeadLine = DeadLineCalendar.SelectedDate;
            project.Budget = decimal.Parse(BudgetTb.Text);
            project.ProjectStatus = ProjectStatus.NotStarted;

            project.ProjectTypeId = context
                                     .ProjectTypes
                                     .Find(int.Parse(PrjTypeDdl.SelectedItem.Value))
                                     .Id;

            project.ProjectCategoryId = context
                                         .ProjectCategories
                                         .Find(int.Parse(PrjCategoryDdl.SelectedItem.Value))
                                         .Id;

            context.Projects.Add(project);

            context.SaveChanges();

            Response.Redirect("~/Views/Manage/Projects/All.aspx");

        }
    }
}