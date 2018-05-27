using System;
using System.Web.Mvc;
using DAISPizza.Models.BindingModels;
using DAISPizza.Server.Filters;
using DAISPizza.Services;

namespace DAISPizza.Server.Controllers
{
    public class UsersController : Controller
    {
        private UserManager userManager;

        public UsersController()
            : this(new UserManager())
        {
        }

        public UsersController(UserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [RejectLoggedInUser]
        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RejectLoggedInUser]
        public ActionResult Register(RegisterUserBindingModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }

            try
            {
                this.userManager.CreateUser(user);
                return this.RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.ValidationMessage = ex.Message;
                return this.View(user);
            }
        }

        [HttpGet]
        [RejectLoggedInUser]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RejectLoggedInUser]
        public ActionResult Login(LoginUserBindingModel user)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(user);
            }

            try
            {
                var userWithPassword = this.userManager.GetUser(user);
                this.Session["user"] = userWithPassword;
                return this.RedirectToAction("Index", "Home");
            }
            catch (ArgumentException)
            {
                ViewBag.ValidationMessage = "Invalid login!";
                return this.View(user);
            }
        }

        public ActionResult Logout()
        {
            if (this.User != null)
            {
                this.Session["user"] = null;
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}