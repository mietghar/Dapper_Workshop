using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repository
{
    public class RepositoryExample_2
    {
        private readonly string ConnectionString;
        public RepositoryExample_2(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int GetInsertQueryRows()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute("PersonInsert",
                    new[]
                    {
                        new {FirstName = "Jerzy", LastName = "Killer", Age = 38, Job = 0},
                        new {FirstName = "Beata", LastName = "Bęben", Age = 33, Job = 2},
                        new {FirstName = "Cyprian", LastName = "Cebula", Age = 23, Job = 0},
                        new {FirstName = "Karol", LastName = "Kowalski", Age = 17, Job = 1}
                    }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public int GetPersonId()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<int>("test", commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
