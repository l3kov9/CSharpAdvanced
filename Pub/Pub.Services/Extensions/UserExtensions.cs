namespace Pub.Services.Extensions
{
    using Models.Users;
    using System.Security.Principal;

    public static class UserExtensions
    {
        public static int GetUserId(this IPrincipal principal)
        {
            if (principal is User client)
            {
                return client.Id;
            }

            return 0;
        }
    }
}
