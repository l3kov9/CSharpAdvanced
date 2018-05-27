using System.Web.Mvc;

namespace DAISPizza.Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}