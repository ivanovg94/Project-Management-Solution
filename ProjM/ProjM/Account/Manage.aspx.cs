using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjM.Models;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ProjM.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private ProjMDbContext conttext;

        public Manage()
        {
            this.conttext = new ProjMDbContext();
        }

        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();


            HasPhoneNumber = String.IsNullOrEmpty(manager.GetPhoneNumber(User.Identity.GetUserId()));

            // Enable this after setting up two-factor authentientication
            //PhoneNumber.Text = manager.GetPhoneNumber(User.Identity.GetUserId()) ?? String.Empty;

            TwoFactorEnabled = manager.GetTwoFactorEnabled(User.Identity.GetUserId());

            LoginsCount = manager.GetLogins(User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (!IsPostBack)
            {
                // Determine the sections to render
                if (HasPassword(manager))
                {
                    ChangePassword.Visible = true;
                }
                else
                {
                    CreatePassword.Visible = true;
                    ChangePassword.Visible = false;
                }

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }

            if (!IsPostBack)
            {
                var db = new ProjMDbContext();
                var currentUserId = User.Identity.GetUserId();
                var currentUser = db.Users.Where(a => a.Id == currentUserId).First();
                UserNameTb.Text = currentUser.UserName;
                PhoneNumberTb.Text = currentUser.Phone;
                ExperienceTextArea.Value = currentUser.Experience;
                StatusLabel.Text = currentUser.UserStatus.ToString();
                switch (currentUser.UserStatus)
                {
                    case UserStatus.Free:
                        StatusLabel.ForeColor = Color.Green;
                        break;
                    case UserStatus.Considering:
                        StatusLabel.ForeColor = Color.Black;
                        break;
                    case UserStatus.Occupied:
                        StatusLabel.ForeColor = Color.Red;
                        break;
                }
                DevSpecDdl.SelectedValue = currentUser.DeveloperSpec.ToString();

                DevSpecDdl.DataSource = Enum.GetNames(typeof(DeveloperSpec));
                DevSpecDdl.DataBind();

                //fill language list with all possible selections
                var languages = db.ProgrammingLanguages.ToList();
                foreach (var lang in languages)
                {
                    LanguagesCbl.Items.Add(new ListItem()
                    {
                        Value = lang.Id.ToString(),
                        Text = lang.Name
                    });
                }

                var currentUserLanguages = currentUser.ProgrammingLanguages.ToList();
                // mark current user selections
                foreach (var item in currentUserLanguages)
                {
                    LanguagesCbl.Items.FindByValue(item.Id.ToString()).Selected = true;
                }

                languages.Clear();
                currentUserLanguages.Clear();

            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }


        protected void SaveDataButton_Click(object sender, EventArgs e)
        {

            var db = new ProjMDbContext();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            if (SaveDataButton.Text == "Save changes")
            {

                currentUser.UserName = UserNameTb.Text;
                currentUser.Phone = PhoneNumberTb.Text;
                currentUser.Experience = ExperienceTextArea.Value;
                currentUser.DeveloperSpec = (DeveloperSpec)Enum.Parse(typeof(DeveloperSpec), DevSpecDdl.SelectedValue);

                foreach (ListItem item in LanguagesCbl.Items)
                {
                    if (item.Selected)
                    {
                        currentUser
                                   .ProgrammingLanguages
                                   .Add(
                                    db.ProgrammingLanguages.Find(int.Parse(item.Value)));
                    }
                    if (!item.Selected)
                    {
                        currentUser
                                   .ProgrammingLanguages
                                   .Remove(
                                    db.ProgrammingLanguages.Find(int.Parse(item.Value)));
                    }
                }

                db.SaveChanges();

                UserNameTb.Enabled = false;
                PhoneNumberTb.Enabled = false;
                ExperienceTextArea.Disabled = true;
                DevSpecDdl.Enabled = false;
                LanguagesCbl.Enabled = false;

                SaveDataButton.Text = "Edit profile";

            }
            else if (SaveDataButton.Text == "Edit profile")
            {
                DevSpecDdl.Enabled = true;
                UserNameTb.Enabled = true;
                PhoneNumberTb.Enabled = true;
                ExperienceTextArea.Disabled = false;
                LanguagesCbl.Enabled = true;
                SaveDataButton.Text = "Save changes";
            }
        }
    }
}