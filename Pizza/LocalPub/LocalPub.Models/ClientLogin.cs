namespace LocalPub.Models
{
    public class ClientLogin : Client
    {
        public ClientLogin(int id, string username, string role, string passwordHash, string passwordSalt)
            : base(id, username, role)
        {
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
