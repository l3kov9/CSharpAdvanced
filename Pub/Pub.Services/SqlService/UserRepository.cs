namespace Pub.Services.SqlService
{
    using Common.SqlServer;
    using Contracts;
    using Data;
    using Models.Users;
    using System;
    using System.Collections.Generic;

    public class UserRepository : DbConnector, IUserRepository
    {
        public UserRepository()
        {
        }

        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public UserServiceModel GetUserByUsername(string username)
        {
            var reader = this.ExecuteReader(QueryConstants.GetUserByUsername, new Dictionary<string, object> { { "@username", username } });

            var counter = 0;
            UserServiceModel user = null;

            while (reader.Read())
            {
                counter++;

                var userId = (int)reader[0];
                var usernameDb = (string)reader[1];
                var firstName = (string)reader[2];
                var lastName = (string)reader[3];
                var email = (string)reader[4];
                var imageUrl = (string)reader[5];
                var passwordHash = (string)reader[6];
                var passwordSalt = (string)reader[7];
                var role = (string)reader[8];

                user = new UserServiceModel(userId, username, firstName, lastName, email, imageUrl, role, passwordHash, passwordSalt);
            }

            if (counter > 1)
            {
                throw new InvalidOperationException("Username must be unique");
            }

            return user;
        }
    }
}
