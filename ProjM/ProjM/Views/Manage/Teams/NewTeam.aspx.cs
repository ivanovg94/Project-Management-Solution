using ProjM.Models;
using ProjM.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.Views.Teams
{
    public partial class NewTeam : System.Web.UI.Page
    {
        ProjMDbContext context = new ProjMDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CurrentProjectIdLabel.Text = MySession.Current.Data1;
            }
        }

        protected void ContinueBtn_Click(object sender, EventArgs e)
        {
            var currentProjectId = int.Parse(CurrentProjectIdLabel.Text);

            //create Team
            var team = new Team();
            team.Name = TeamNameTb.Text;
            team.ReqNumFrontEnd = int.Parse(FrontEndTb.Text);
            team.ReqNumBackEnd = int.Parse(BackEndTb.Text);
            team.ReqNumQA = int.Parse(QATb.Text);
            team.CurrentNumBackEnd = 0;
            team.CurrentNumFrontEnd = 0;
            team.CurrentNumQA = 0;
            team.TeamStatus = TeamStatus.Incomplete;
            team.Projects.Add(context.Projects.Where(x => x.Id == currentProjectId).First());

            //save Team
            context.Teams.Add(team);
            context.SaveChanges();

            //set Team to current project  
            var currentTeamId = context.Teams.FirstOrDefault(x => x.Name == TeamNameTb.Text).Id;

            //send teamId to next form
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamId.ToString());
        }
    }
}