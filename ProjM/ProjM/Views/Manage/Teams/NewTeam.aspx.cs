namespace ProjM.Views.Teams
{
    using Models;
    using Sessions;
    using System;
    using System.Linq;
    public partial class NewTeam : System.Web.UI.Page
    {
        ProjMDbContext context = new ProjMDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void ContinueBtn_Click(object sender, EventArgs e)
        {
            var currentProjectId = int.Parse(MySession.Current.Data1);

            //create Team
            var team = new Team
            {
                Name = TeamNameTb.Text,
                ReqNumFrontEnd = int.Parse(FrontEndTb.Text),
                ReqNumBackEnd = int.Parse(BackEndTb.Text),
                ReqNumQA = int.Parse(QATb.Text),
                CurrentNumBackEnd = 0,
                CurrentNumFrontEnd = 0,
                CurrentNumQA = 0,
                TeamStatusId = 1
            };

            team.Projects.Add(context.Projects.Where(x => x.Id == currentProjectId).First());

            //save Team
            context.Teams.Add(team);
            context.SaveChanges();

            var currentTeamId = context.Teams.FirstOrDefault(x => x.Name == TeamNameTb.Text).Id;

            //send teamId to next form
            Response.Redirect("~/Views/Manage/Teams/Assembly.aspx?id=" + currentTeamId.ToString());
        }
    }
}