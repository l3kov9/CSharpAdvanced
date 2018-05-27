using LocalPub.Domain.Managers;
using LocalPub.Server.Filters;
using System.Web.Mvc;

namespace LocalPub.Server.Controllers
{
    [AuthorizeClient]
    public class MenuController : Controller
    {
        private MenuManager menuManager;

        public MenuController()
            : this(new MenuManager())
        {
        }

        public MenuController(MenuManager menuManager)
        {
            this.menuManager = menuManager;
        }

        [HttpGet]
        public ActionResult MostWanted()
        {
            var mostWantedMeals = this.menuManager.GetMostWantedMeals();
            return this.View(mostWantedMeals);
        }

        [HttpGet]
        [AuthorizeClient(Roles = "Връзкар")]
        public ActionResult MealsByDate()
        {
            var mealsByDate = this.menuManager.GetMealsByDate();
            return this.View(mealsByDate);
        }
    }
}