namespace BirthdayPresent.Services
{
    using Common.Authentication;
    using Contracts;
    using Models.Employees;
    using SqlServer;

    public class EmployeeService
    {
        private IEmployeeRepository userRepository;

        public EmployeeService()
            : this(new EmployeeRepository())
        {
        }

        public EmployeeService(EmployeeRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public EmployeeServiceModel GetUser(string username, string password)
        {
            var user = this.userRepository.GetUserByUsername(username);

            if (user == null)
            {
                return null;
            }

            var actualPasswordHash = PasswordUtilities.GeneratePasswordHash(password, user.PasswordSalt).ToUpper();

            if (actualPasswordHash != user.PasswordHash)
            {
                // Password doesn't match the record in the database
                return null;
            }

            return user;
        }
    }
}
