using System.Web.Mvc;
using System.Web.Mvc.Filters;
using DAISPizza.Models;

namespace DAISPizza.Server.Filters
{
    public class InsertUserAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["user"] as User;
            if (user != null)
            {
                filterContext.Principal = user;
            }
            else
            {
                filterContext.Principal = null;
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // This is not needed, we can just skip it
        }
    }
}