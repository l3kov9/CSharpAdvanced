using System.Web.Mvc;
using DAISPizza.Services;

namespace DAISPizza.Server.Controllers
{
    public class MenuController : Controller
    {
        private PizzaManager pizzaManager;

        public MenuController()
            : this(new PizzaManager())
        {
        }

        public MenuController(PizzaManager pizzaManager)
        {
            this.pizzaManager = pizzaManager;
        }

        public ActionResult Index()
        {
            var pizzas = this.pizzaManager.GetPizzas();
            return this.View(pizzas);
        }

        [ChildActionOnly]
        public ActionResult MostWantedPizza()
        {
            var pizza = this.pizzaManager.GetMostWantedPizza();
            return this.PartialView(pizza);
        }
    }
}