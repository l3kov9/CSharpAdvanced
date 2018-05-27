using LocalPub.Domain.Interfaces;
using LocalPub.Domain.SqlServer;
using LocalPub.Models;
using LocalPub.Utilities;
using System;

namespace LocalPub.Domain.Managers
{
    public class ClientManager
    {
        private IClientRepository clientRepository;

        public ClientManager()
            : this(new SqlClientRepository())
        {
        }

        public ClientManager(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public ClientLogin GetClient(ClientLoginModel client)
        {
            var clientFromDb = this.clientRepository.GetClientByUsername(client.Username);
            if (clientFromDb == null)
            {
                // No such username
                return null;
            }

            var actualPasswordHash = PasswordUtilities.GeneratePasswordHash(client.Password, clientFromDb.PasswordSalt);
            if (actualPasswordHash != clientFromDb.PasswordHash)
            {
                // Password doesn't match the record in the database
                return null;
            }

            return clientFromDb;
        }
    }
}
