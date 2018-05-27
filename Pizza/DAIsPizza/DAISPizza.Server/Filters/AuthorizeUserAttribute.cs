using System.Web.Mvc;
using System.Web.Routing;

namespace DAISPizza.Server.Filters
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User == null)
            {
                var loginRoute = new RouteValueDictionary(new { controller = "Users", action = "Login" });
                filterContext.Result = new RedirectToRouteResult(loginRoute);
            }
        }
    }
}