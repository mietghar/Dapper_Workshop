using Dapper;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class InitializationRepository
    {
        private readonly string ConnectionString;

        public InitializationRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void InsertIntoPersonTable()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("IF NOT EXISTS (SELECT Id FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName)" +
                    "BEGIN INSERT INTO Employee (FirstName, LastName, AddressId) " +
                    "Values (@FirstName, @LastName, @AddressId, @Job) END",
                    new[]
                    {
                        new {FirstName = "Michał", LastName = "Gwóźdź", AddressId = 1},
                        new {FirstName = "Łukasz", LastName = "Szustak", AddressId = 2}
                    });
            }
        }
    }
}
