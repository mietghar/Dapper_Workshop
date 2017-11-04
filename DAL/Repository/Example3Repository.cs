using Dapper;
using System.Data.SqlClient;
using System.Linq;
using DAL.ViewModel;
using System;

namespace DAL.Repository
{
    public class Example3Repository
    {
        private readonly string _connectionString;
        public Example3Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object GetFirstEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
                return connection.QueryFirst<EmployeeDTO>("SELECT * FROM Employee");
        }

        public object GetFirstEmployeeFiltered()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
                return connection.Query<EmployeeDTO>("SELECT * FROM Employee").First();
        }

        public void PopulateEmployeeWithFakeData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
                for (int i = 0; i < 50000; i++)
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

        public void ClearAllEmployeeData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Query("TRUNCATE TABLE Employee", null, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        try
                        {
                            Console.WriteLine("Exception thrown during truncating table Employee, try to rollback changes");
                            transaction.Rollback();
                        }
                        catch
                        {
                            Console.WriteLine("Rollback failed");
                        }
                    }
                }
            }
        }
    }
}
