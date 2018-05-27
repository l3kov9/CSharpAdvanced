using System.Web.Mvc;

namespace LocalPub.Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.RedirectToAction("Login", "Clients");
        }
    }
}