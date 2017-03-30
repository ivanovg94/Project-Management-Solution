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
            }

            var db = new ProjMDbContext();

            var project = new Project();


            //TextBox1.Text= db
            //                   .Projects
            //                   .Find(queryStringID)
            //                   .Name;

        




        }

        
    }
}