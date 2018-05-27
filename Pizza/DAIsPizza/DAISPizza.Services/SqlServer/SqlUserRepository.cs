using System.Collections.Generic;
using DAISPizza.Models;
using DAISPizza.Services.Interfaces;

namespace DAISPizza.Services.SqlServer
{
    public class SqlUserRepository : DbRepository, IUserRepository
    {
        public SqlUserRepository(string connectionString)
            : base(connectionString)
        {
        }

        public SqlUserRepository()
            : base("Data Source=.;Integrated Security=True;Database=DAIsPizza")
        {
        }

        public int GetUsersCountByUsername(string username)
        {
            using (this)
            {
                return (int)this.ExecuteScalar(
                   @"select count(*)
                    from Users
                    where Username = @username",
                   new Dictionary<string, object>()
                   {
                        { "@username", username }
                   });
            }
        }

        public User GetUserByUsername(string username)
        {
            using (this)
            {
                var reader = this.ExecuteReader(
                    @"select Id, Username, PasswordHash, PasswordSalt from Users
                        where Username = @username",
                    new Dictionary<string, object> { { "@username", username } });
                User user = null;

                using (reader)
                {
                    for (int usersCount = 0; reader.Read() && usersCount <= 1; usersCount++)
                    {
                        int id = reader.GetInt32(0);
                        string usernameFromDatabase = reader.GetString(1);
                        string passwordHash = reader.GetString(2);
                        string passwordSalt = reader.GetString(3);
                        user = new User(id, usernameFromDatabase, passwordHash, passwordSalt);
                    }
                }

                return user;
            }
        }

        public void CreateUser(UserCreationModel user)
        {
            using (this)
            {
                this.ExecuteNonQuery(
                    @"insert into Users (Username, Address, Phone, PasswordHash, PasswordSalt)
                        values (@username, @address, @phone, @passwordHash, @passwordSalt)",
                    new Dictionary<string, object>()
                    {
                        { "@username", user.Username },
                        { "@address", user.Address },
                        { "@phone", user.Phone },
                        { "@passwordHash", user.PasswordHash },
                        { "@passwordSalt", user.PasswordSalt }
                    });
            }
        }
    }
}
