using LocalPub.Models;
using System.Security.Principal;

public static class ClientExtensions
{
    public static int GetUserId(this IPrincipal principal)
    {
        var client = principal as Client;
        if (client != null)
        {
            return client.Id;
        }

        return 0;
    }
}