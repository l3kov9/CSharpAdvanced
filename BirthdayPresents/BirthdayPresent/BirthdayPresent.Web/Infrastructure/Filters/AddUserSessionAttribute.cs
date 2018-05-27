namespace BirthdayPresent.Web.Infrastructure.Filters
{
    using Common.Authentication;
    using Services.Models.Employees;
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;

    public class AddUserSessionAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.HttpContext.Session[AuthenticationConstants.SessionUserKey] is Employee employee)
            {
                filterContext.Principal = employee;
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}