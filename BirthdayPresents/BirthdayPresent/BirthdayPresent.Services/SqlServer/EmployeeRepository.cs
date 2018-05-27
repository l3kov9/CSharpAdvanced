namespace BirthdayPresent.Services.SqlServer
{
    using Common.SqlServer;
    using Contracts;
    using Data;
    using Models.Employees;
    using System;
    using System.Collections.Generic;

    public class EmployeeRepository : DbConnector, IEmployeeRepository
    {
        public EmployeeRepository()
        {
        }

        public EmployeeRepository(string connectionString) : base(connectionString)
        {
        }

        public EmployeeServiceModel GetUserByUsername(string username)
        {
            var reader = this.ExecuteReader(QueryConstants.GetUserByUsername, new Dictionary<string, object> { { "@username", username } });

            var counter = 0;
            EmployeeServiceModel user = null;

            while (reader.Read())
            {
                counter++;

                var userId = (int)reader[0];
                var usernameDb = (string)reader[1];
                var email = (string)reader[2];
                var imageUrl = (string)reader[3];
                var birthDate = (DateTime)reader[4];
                var passwordHash = (string)reader[5];
                var passwordSalt = (string)reader[6];

                user = new EmployeeServiceModel(userId, username, email, imageUrl, birthDate, passwordHash, passwordSalt);
            }

            if (counter > 1)
            {
                throw new InvalidOperationException("Username must be unique");
            }

            return user;
        }
    }
}
