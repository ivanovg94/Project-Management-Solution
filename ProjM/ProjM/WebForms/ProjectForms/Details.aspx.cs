using ProjM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.WebForms.ProjectForms
{
    public partial class Details : Page
    {
        int queryStringID = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                queryStringID = int.Parse(Request.QueryString["id"]);
                var currentId = queryStringID;
                var context = new ProjMDbContext();
               
                var currentProject = context.Projects.Find(currentId);

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




            }


            //TextBox1.Text= db
            //                   .Projects
            //                   .Find(queryStringID)
            //                   .Name;







        }


    }
}