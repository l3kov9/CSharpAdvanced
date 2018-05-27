namespace BirthdayPresent.Services.Contracts
{
    using Data;
    using Models.Employees;

    public interface IEmployeeRepository : IDbConnector
    {
        EmployeeServiceModel GetUserByUsername(string username);
    }
}
