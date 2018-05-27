using System.Web.Mvc;
using System.Web.Routing;

namespace DAISPizza.Server.Filters
{
    public class RejectLoggedInUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User != null)
            {
                var homePageRoute = new RouteValueDictionary(new { controller = "Home", action = "Index" });
                filterContext.Result = new RedirectToRouteResult(homePageRoute);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}