using Dapper;
using System.Data.SqlClient;
using System;

namespace DAL.Repository
{
    public class InitializationRepository
    {
        private readonly string ConnectionString;

        public InitializationRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Initialize()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(Scripts.InitializeScripts);
            }
        }
    }
}
