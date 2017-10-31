using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Repository
{
    public class Example2Repository
    {
        private readonly string ConnectionString;
        public Example2Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int GetInsertQueryRows()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute("EmployeeInsert",
                    new[]
                    {
                        new {FirstName = "Jerzy", LastName = "Killer", AddressId = 38},
                        new {FirstName = "Beata", LastName = "Bęben", AddressId = 33},
                        new {FirstName = "Cyprian", LastName = "Cebula", AddressId = 7},
                        new {FirstName = "Karol", LastName = "Kowalski", AddressId = 8}
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
