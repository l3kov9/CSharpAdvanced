namespace Pub.Common.SqlServer
{
    public class QueryConstants
    {
        public const string GetUserByUsername = @"SELECT u.Id, u.Username, u.FirstName, u.LastName, u.Email, u.ImageUrl, u.PasswordHash, u.PasswordSalt, r.Name FROM Users AS u 
JOIN Roles AS r ON r.Id = u.RoleId
WHERE u.Username = @username";
    }
}
