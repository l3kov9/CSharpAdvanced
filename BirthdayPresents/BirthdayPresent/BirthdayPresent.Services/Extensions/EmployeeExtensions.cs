namespace BirthdayPresent.Services.Extensions
{
    using Models.Employees;
    using System.Security.Principal;

    public static class EmployeeExtensions
    {
        public static int GetUserId(this IPrincipal principal)
        {
            if (principal is Employee employee)
            {
                return employee.Id;
            }

            return 0;
        }
    }
}
