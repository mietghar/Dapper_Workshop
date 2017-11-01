using Dapper;
using System.Data.SqlClient;
using System.Linq;
using DAL.ViewModel;

namespace DAL.Repository
{
    public class Example3Repository
    {
        private readonly string ConnectionString;
        public Example3Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public object GetFirstEmployee()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirst<EmployeeDTO>("SELECT * FROM Employee");
            }
        }

        public object GetFirstEmployeeFiltered()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<EmployeeDTO>("SELECT * FROM Employee").First();
            }
        }

        public void PopulateEmployeeWithFakeData()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                for (int i = 0; i < 10000; i++)
                {
                    connection.Query("INSERT INTO Employee (FirstName, LastName, AddressId, UserId) VALUES (@FirstName, @LastName, @AddressId, @UserId)",
                           new
                           {
                               FirstName = "FakeName",
                               LastName = "FakeName",
                               AddressId = 1,
                               UserId = 1
                           });
                }                    
            }
        }
    }
}
