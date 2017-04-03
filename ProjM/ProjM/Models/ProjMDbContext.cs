using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjM.Models;
using System.Data.Entity;

namespace ProjM.Models
{


    public class ProjMDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProjMDbContext()
            : base("ProjM", throwIfV1Schema: false)
        {
        }




        public virtual IDbSet<Project> Projects { get; set; }
        public virtual IDbSet<ProjectCategory> ProjectCategories { get; set; }
        public virtual IDbSet<ProjectType> ProjectTypes { get; set; }
        public virtual IDbSet<Team> Teams { get; set; }
        public virtual IDbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public virtual IDbSet<UserRank> UserRanks { get; set; }



        public static ProjMDbContext Create()
        {
            return new ProjMDbContext();
        }
    }
}

#region Helpers
namespace ProjM
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request.QueryString[ProviderNameKey];
        }

        public const string CodeKey = "code";
        public static string GetCodeFromRequest(HttpRequest request)
        {
            return request.QueryString[CodeKey];
        }

        public const string UserIdKey = "userId";
        public static string GetUserIdFromRequest(HttpRequest request)
        {
            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        }

        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
        {
            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
        {
            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
#endregion
