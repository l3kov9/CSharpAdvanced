namespace BirthdayPresent.Common.SqlServer
{
    public class QueryConstants
    {
        public const string GetUserByUsername = @"SELECT Id, Username, Email, ImageUrl, Birthdate, PasswordHash, PasswordSalt FROM Employees
WHERE Username = @username";
    }
}
