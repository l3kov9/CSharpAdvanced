using LocalPub.Domain.Managers;
using LocalPub.Models;
using LocalPub.Server.Filters;
using LocalPub.Utilities;
using System.Web.Mvc;

namespace LocalPub.Server.Controllers
{
    public class ClientsController : Controller
    {
        private ClientManager clientManager;

        public ClientsController()
            : this(new ClientManager())
        {
        }

        public ClientsController(ClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [HttpGet]
        [RedirectLoggedInUser]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RedirectLoggedInUser]
        public ActionResult Login(ClientLoginModel client)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(client);
            }

            var actualClient = this.clientManager.GetClient(client);
            if (actualClient == null)
            {
                this.ModelState.AddModelError("Form", "The username and / or password are incorrect");
                return this.View(client);
            }
            else
            {
                this.Session[AuthConstants.SessionUserKey] = actualClient;
                return this.RedirectToAction("Index", "Orders");
            }
        }

        [AuthorizeClient]
        public ActionResult Logout()
        {
            this.Session[AuthConstants.SessionUserKey] = null;
            return this.RedirectToAction("Index", "Home");
        }
    }
}