using DAISPizza.Models.BindingModels;
using DAISPizza.Server.Filters;
using DAISPizza.Server.ModelBinders;
using DAISPizza.Services;
using System.Web.Mvc;

namespace DAISPizza.Server.Controllers
{
    public class OrdersController : Controller
    {
        private PizzaManager pizzaManager;

        public OrdersController()
            : this(new PizzaManager())
        {
        }

        public OrdersController(PizzaManager pizzaManager)
        {
            this.pizzaManager = pizzaManager;
        }

        [HttpGet]
        [AuthorizeUser]
        public ActionResult OrderPizza(int id)
        {
            var pizza = this.pizzaManager.GetPizzaToOrder(id);
            return this.View(pizza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeUser]
        public ActionResult OrderPizza(
            [ModelBinder(typeof(IngredientsCollectionModelBinder))]PizzaOrderBindingModel pizza)
        {
            // TODO: Proceed to checkout
            // TODO: Multiple orders
            return this.View();
        }
    }
}