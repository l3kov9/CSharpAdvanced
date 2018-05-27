using LocalPub.Models;

namespace LocalPub.Domain.Interfaces
{
    public interface IClientRepository : IDbRepository
    {
        ClientLogin GetClientByUsername(string username);
    }
}
