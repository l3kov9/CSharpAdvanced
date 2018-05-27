namespace Pub.Services.Models.Users
{
    public class UserServiceModel : User
    {
        public UserServiceModel(int id, string username, string firstName, string lastName, string email, string imageUrl, string role, string passwordHash, string passwordSalt)
            : base(id, username, role)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.ImageUrl = imageUrl;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
