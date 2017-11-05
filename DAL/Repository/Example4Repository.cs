using DAL.ViewModel;
using Dapper;
using System;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class Example4Repository
    {
        private readonly string _connectionString;
        public Example4Repository(string connectionString)
        {
            _connectionString = connectionString;
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
                    catch(Exception exception)
                    {
                        try
                        {
                            Console.WriteLine("Exception thrown during truncating table Employee, try to rollback changes");
                            transaction.Rollback();
                            Console.WriteLine("Rollback success");
                        }
                        catch
                        {
                            Console.WriteLine("Rollback failed");
                        }
                    }
                }
            }
        }

        public object GetFirstOrDefaultEmployee()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault("SELECT * FROM Employee");
            }
        }
    }
}
