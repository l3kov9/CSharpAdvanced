using System;

namespace BirthdayPresent.Services.Models.Employees
{
    public class EmployeeServiceModel : Employee
    {
        public EmployeeServiceModel(int id, string username, string email, string imageUrl, DateTime birthdat, string passwordHash, string passwordSalt)
            : base(id, username)
        {
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
