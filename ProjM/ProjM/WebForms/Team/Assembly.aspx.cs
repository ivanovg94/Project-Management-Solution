using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjM.Models;
using ProjM.ViewModels;
using System;
using System.Collections.Generic;
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



            if (!IsPostBack)
            {


                var db = new ProjMDbContext();

                var userRolesId = new List<string>();
                var users = db.Users.ToList();
                foreach (var user in users)
                {
                    userRolesId.AddRange(user.Roles.Select(m => m.RoleId));
                }
                userRolesId = userRolesId.Distinct().ToList();
                var roleName = db.Roles.Where(r => userRolesId.Contains(r.Id)).Select(x => x.Name).FirstOrDefault();

                var gridData = db
                            .Users
                            .Include(x => x.Roles)
                            .Include(x => x.UserRank)

                            .Select(x => new DevVM()
                            {
                                Name = x.UserName,
                                Speciality = x.DeveloperSpec.ToString(),
                                Type = roleName,
                                Rank = x.UserRank.RankName


                            })
                                .ToList();
                gridData.Remove(gridData.FirstOrDefault(x => x.Name == "hr@hr.com"));

                AllDevsGv.DataSource = gridData;
                AllDevsGv.DataBind();


            }




        }
    }
}