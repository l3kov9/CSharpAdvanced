namespace DAISPizza.Models
{
    public abstract class UserLogin : IdentifiedObject
    {
        public UserLogin(int id, string username, string passwordHash, string passwordSalt)
            : base(id)
        {
            this.Username = username;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
