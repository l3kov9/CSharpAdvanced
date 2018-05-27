using LocalPub.Domain.Managers;
using LocalPub.Models;
using LocalPub.Models.BindingModels;
using LocalPub.Server.Filters;
using LocalPub.Server.ModelBinders;
using System;
using System.Web.Mvc;

namespace LocalPub.Server.Controllers
{
    [AuthorizeClient]
    public class OrdersController : Controller
    {
        private OrderManager orderManager;

        public OrdersController()
            : this(new OrderManager())
        {
        }

        public OrdersController(OrderManager clientManager)
        {
            this.orderManager = clientManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var orders = this.orderManager.GetAllOrders(this.User.GetUserId());
            return this.View(orders);
        }

        [HttpGet]
        public ActionResult MakeOrder()
        {
            var menu = this.orderManager.PrepareOrderMenu();
            ViewBag.AppetizersList = new SelectList(menu.Appetizers, "Id", "Name", "-- none --");
            ViewBag.MainCoursesList = new SelectList(menu.MainCourses, "Id", "Name", "-- none --");
            ViewBag.DessertsList = new SelectList(menu.Desserts, "Id", "Name", "-- none --");

            if (this.User.IsInRole("Връзкар"))
            {
                var orderModel = new PrivilegedUserOrderBindingModel();
                return this.View(viewName: "MakeOrderPrivileged");
            }
            else
            {
                return this.View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeOrder([ModelBinder(typeof(DateModelBinder))]OrderBindingModel order)
        {
            return this.TrySaveOrder(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Връзкар")]
        public ActionResult MakeOrderPrivileged([ModelBinder(typeof(DateModelBinder))]PrivilegedUserOrderBindingModel order)
        {
            return this.TrySaveOrder(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            this.orderManager.CancelOrder(id, this.User.GetUserId());
            return this.RedirectToAction("Index", "Orders");
        }

        private ActionResult TrySaveOrder(OrderBindingModel order)
        {
            order.ClientId = this.User.GetUserId();
            bool saveSuccess = this.orderManager.SaveOrder(order);

            if (!saveSuccess)
            {
                this.ModelState.AddModelError("Form", "The order was not saved correctly.");
                return this.MakeOrder();
            }

            return this.RedirectToAction("Index", "Orders");
        }
    }
}