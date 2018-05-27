using System.Security.Principal;

namespace DAISPizza.Models
{
    public class User : UserLogin, IPrincipal
    {
        public User(int id, string username, string passwordHash, string passwordSalt)
            : base(id, username, passwordHash, passwordSalt)
        {
            this.Identity = new GenericIdentity(username);
        }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            // There are currently no roles defined
            return false;
        }
    }
}