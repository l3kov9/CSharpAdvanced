using LocalPub.Server.Filters;
using System.Web.Mvc;

namespace LocalPub.Server
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InsertUserAttribute());
        }
    }
}
