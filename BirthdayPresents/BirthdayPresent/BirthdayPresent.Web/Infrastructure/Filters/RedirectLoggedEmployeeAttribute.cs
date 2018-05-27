﻿namespace BirthdayPresent.Web.Infrastructure.Filters
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RedirectLoggedEmployeeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Home", action = "Index" }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}