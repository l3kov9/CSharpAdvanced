using DAISPizza.Services.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAISPizza.Services
{
    public abstract class DbRepository : IDbRepository
    {
        public DbRepository(string connectionString)
        {
            this.Connection = new SqlConnection(connectionString);
            this.Connection.Open();
        }

        protected SqlConnection Connection { get; private set; }

        public SqlDataReader ExecuteReader(string commandText, IDictionary<string, object> parameters = null)
        {
            var command = this.PrepareCommand(commandText, parameters);
            return command.ExecuteReader();
        }

        public object ExecuteScalar(string commandText, IDictionary<string, object> parameters = null)
        {
            var command = this.PrepareCommand(commandText, parameters);
            return command.ExecuteScalar();
        }

        public int ExecuteNonQuery(string commandText, IDictionary<string, object> parameters = null)
        {
            var command = this.PrepareCommand(commandText, parameters);
            return command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.Connection.Close();
        }

        private SqlCommand PrepareCommand(string commandText, IDictionary<string, object> parameters = null)
        {
            //var command = new SqlCommand(commandText, this.Connection);
            var command = this.Connection.CreateCommand();
            command.CommandText = commandText;
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            return command;
        }
    }
}
