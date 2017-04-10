using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjM.Models;
using ProjM.Msg;
using ProjM.Sessions;
using ProjM.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjM.WebForms.Team
{
    public partial class Assembly : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProjMDbContext context = new ProjMDbContext();
            int queryStringID = int.Parse(Request.QueryString["id"]);

            var currentTeam = context.Teams.Find(queryStringID);

            if (!IsPostBack)
            {
                //fill Project Details
                int currentProjectId = int.Parse(MySession.Current.Data1);
                var currentProject = context.Projects.Where(x => x.Id == currentProjectId).First();
                ProjectNameLValue.Text = currentProject.Name;
                ProjectTypeLValue.Text = currentProject.ProjectType.Name;
                ProjectCategoryLValue.Text = currentProject.ProjectCategory.Name;
                BudgetLValue.Text = currentProject.Budget.ToString();

                //fill Team Details


                FrontEndLValue.Text = currentTeam.ReqNumFrontEnd.ToString();
                BackEndLValue.Text = currentTeam.ReqNumBackEnd.ToString();
                QALValue.Text = currentTeam.ReqNumQA.ToString();
                TotalLValue.Text = (currentTeam.ReqNumBackEnd + currentTeam.ReqNumFrontEnd + currentTeam.ReqNumQA).ToString();


                //fill AllUsers Grid 
                var gridData = context
                            .Users
                            .Include(x => x.Roles)
                            .Include(x => x.UserRank)
                            .Select(x => new DevVM()
                            {
                                Id = x.Id,
                                Name = x.UserName,
                                Speciality = x.DeveloperSpec.ToString(),
                                Type = context.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name,
                                Rank = x.UserRank.RankName
                            })
                            .ToList();
                gridData.Remove(gridData.FirstOrDefault(x => x.Name == "hr@hr.com"));
                AllDevsGv.DataSource = gridData;
                AllDevsGv.DataBind();
            }

            CurrentFrontEndLValue.Text = currentTeam.CurrentNumFrontEnd.ToString();
            CurrentBackEndLValue.Text = currentTeam.CurrentNumBackEnd.ToString();
            CurrentQALValue.Text = currentTeam.CurrentNumQA.ToString();
            CurrentTotalLValue.Text = (currentTeam.CurrentNumQA + currentTeam.CurrentNumFrontEnd + currentTeam.CurrentNumBackEnd).ToString();



            var secondGridData = context
                           .Users
                           .Where(x => x.TeamId == queryStringID)
                           .Include(x => x.Roles)
                           .Include(x => x.UserRank)

                           .Select(x => new DevVM()
                           {
                               Id = x.Id,
                               Name = x.UserName,
                               Speciality = x.DeveloperSpec.ToString(),
                               Type = context.Roles.FirstOrDefault(r => r.Id == x.Roles.FirstOrDefault().RoleId).Name,
                               Rank = x.UserRank.RankName
                           })
                           .ToList();
            TeamDevsGv.DataSource = secondGridData;
            TeamDevsGv.DataBind();

        }


        //row button event
        protected void AllDevsGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var context = new ProjMDbContext();
            int index = 0;
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            //GridView second = TeamDevsGv as GridView;
            //GridViewRow secondRow;


            if (e.CommandName == "Add")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];

                userId = row.Cells[1].Text;
                var user = context.Users.Find(userId);

                int currentTeamID = int.Parse(Request.QueryString["id"]);
                var currentTeam = context.Teams.Find(currentTeamID);

                if (user.DeveloperSpec == DeveloperSpec.Backend && currentTeam.CurrentNumBackEnd < currentTeam.ReqNumBackEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumBackEnd++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.Backend && currentTeam.CurrentNumBackEnd >= currentTeam.ReqNumBackEnd)
                {
                    MessageBox.Show(this, "Back-end possitions are full!");
                }

                if (user.DeveloperSpec == DeveloperSpec.Frontend && currentTeam.CurrentNumFrontEnd < currentTeam.ReqNumFrontEnd)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumFrontEnd++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.Frontend && currentTeam.CurrentNumFrontEnd >= currentTeam.ReqNumFrontEnd)
                {
                    MessageBox.Show(this, "Front-end possitions are full!");
                }

                if (user.DeveloperSpec == DeveloperSpec.QA && currentTeam.CurrentNumQA < currentTeam.ReqNumQA)
                {
                    user.TeamId = currentTeamID;
                    currentTeam.CurrentNumQA++;
                }
                else if (user.DeveloperSpec == DeveloperSpec.QA && currentTeam.CurrentNumQA >= currentTeam.ReqNumQA)
                {
                    MessageBox.Show(this, "QA possitions are full!");
                }



                context.SaveChanges();

                // row.Enabled = false;



                Response.Redirect("~/Views/Teams/Assembly.aspx?id=" + currentTeamID);
            }
        }

        //hide userId
        protected void AllDevsGv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }


        protected void TeamDevGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var context = new ProjMDbContext();
            int index = 0;
            string userId = "";
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "Remove")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                userId = row.Cells[1].Text;

                var user = context.Users.Find(userId);
                int currentTeamID = int.Parse(Request.QueryString["id"]);
                var currentTeam = context.Teams.Find(currentTeamID);
                user.TeamId = null;

                switch (user.DeveloperSpec)
                {
                    case DeveloperSpec.Backend: currentTeam.CurrentNumBackEnd--; break;
                    case DeveloperSpec.Frontend: currentTeam.CurrentNumFrontEnd--; break;
                    case DeveloperSpec.QA: currentTeam.CurrentNumQA--; break;
                }
                context.SaveChanges();

                //enable

                //GridView first = AllDevsGv as GridView;
                //GridViewRow firstRow;
                // firstRow = first.Rows
                //    .Cast<GridViewRow>()
                //    .Where(r => r.Cells[1].Text.Equals(userId))
                //    .First();
                //firstRow.Enabled = true;


                Response.Redirect("~/Views/Teams/Assembly.aspx?id=" + currentTeamID);
            }
        }

        protected void TeamDevsGv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

    }
}