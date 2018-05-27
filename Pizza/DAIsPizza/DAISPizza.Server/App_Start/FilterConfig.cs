using System.Web.Mvc;
using DAISPizza.Server.Filters;

namespace DAISPizza.Server
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
