using System.Web.Mvc;
using System.Web.Routing;

namespace LocalPub.Server.Filters
{
    public class RedirectLoggedInUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Orders", action = "Index" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}