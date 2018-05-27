namespace BirthdayPresent.Web.Controllers
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<string> { "pesho", "gosho" });
        }
    }
}