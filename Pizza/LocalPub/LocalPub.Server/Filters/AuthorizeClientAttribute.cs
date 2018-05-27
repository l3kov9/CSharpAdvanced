using System.Web.Mvc;
using System.Web.Routing;

namespace LocalPub.Server.Filters
{
    public class AuthorizeClientAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Clients", action = "Login" }));
        }
    }
}