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
                connection.Execute("IF NOT EXISTS (SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName)" +
                    "BEGIN INSERT INTO Person (FirstName, LastName, Age, Job) " +
                    "Values (@FirstName, @LastName, @Age, @Job) END",
                    new[]
                    {
                        new {FirstName = "Michał", LastName = "Gwóźdź", Age = 27, Job = 2},
                        new {FirstName = "Łukasz", LastName = "Szustak", Age = 25, Job = 2}
                    });
            }
        }
    }
}
