namespace BirthdayPresent.Web.Controllers
{
    using Common.Authentication;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Models.Employees;
    using Services;
    using System.Web.Mvc;

    public class EmployeesController : Controller
    {
        private EmployeeService users;

        public EmployeesController()
            : this(new EmployeeService())
        {
        }

        public EmployeesController(EmployeeService users)
        {
            this.users = users;
        }

        [HttpGet]
        [RedirectLoggedEmployee]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [RedirectLoggedEmployee]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var loggedUser = this.users.GetUser(user.Username, user.Password);

            if (loggedUser == null)
            {
                this.TempData.AddErrorMessage("Invalid Login!");

                return this.View(user);
            }
            else
            {
                this.Session[AuthenticationConstants.SessionUserKey] = loggedUser;
                this.TempData.AddSuccessMessage(string.Format("Welcome {0}", loggedUser.Username));

                return this.RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            this.Session[AuthenticationConstants.SessionUserKey] = null;
            this.TempData.AddErrorMessage("You've successfully logged out");

            return RedirectToAction("Index", "Home");
        }
    }
}