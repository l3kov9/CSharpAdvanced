using LocalPub.Domain.Interfaces;
using LocalPub.Models;
using System.Collections.Generic;

namespace LocalPub.Domain.SqlServer
{
    public class SqlClientRepository : DbRepository, IClientRepository
    {
        public SqlClientRepository()
        {
        }

        public SqlClientRepository(string connectionString)
            : base(connectionString)
        {
        }

        public ClientLogin GetClientByUsername(string username)
        {
            var reader = this.ExecuteReader(
                    @"select
	                    c.Id,
	                    c.Username,
	                    c.PasswordHash,
	                    c.PasswordSalt,
	                    ct.Name as RoleName
                    from Clients as c
                    join ClientTypes as ct
                    on c.ClientTypeId = ct.Id
                    where Username = @username",
                    new Dictionary<string, object> { { "@username", username } });
            ClientLogin client = null;
            using (reader)
            {
                for (int usersCount = 0; reader.Read() && usersCount <= 1; usersCount++)
                {
                    int id = reader.GetInt32(0);
                    string usernameFromDatabase = reader.GetString(1);
                    string passwordHash = reader.GetString(2);
                    string passwordSalt = reader.GetString(3);
                    string roleName = reader.GetString(4);
                    client = new ClientLogin(id, usernameFromDatabase, roleName, passwordHash, passwordSalt);
                }
            }

            return client;
        }
    }
}
