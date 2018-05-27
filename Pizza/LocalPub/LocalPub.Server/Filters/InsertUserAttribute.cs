using LocalPub.Models;
using LocalPub.Utilities;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LocalPub.Server.Filters
{
    public class InsertUserAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var client = filterContext.HttpContext.Session[AuthConstants.SessionUserKey] as Client;
            if (client != null)
            {
                filterContext.Principal = client;
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // This is not needed, we can just skip it
        }
    }
}