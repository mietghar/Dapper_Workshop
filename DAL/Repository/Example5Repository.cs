using DAL.ViewModel;
using Dapper;
using System;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class Example5Repository
    {
        private readonly string _connectionString;
        public Example5Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object GetSingleAddress()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                return connection.QuerySingle<AddressDTO>("SELECT * FROM Address");
            }
        }

        public void ClearAllAddressData()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Query("TRUNCATE TABLE Address", null, transaction);
                        transaction.Commit();
                    }
                    catch
                    {
                        try
                        {
                            Console.WriteLine("Exception thrown during truncating table Address, try to rollback changes");
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

        public void AddSingleFakeAddress()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute("INSERT INTO Address (City, PostCode, Street, HouseNumber, LocalNumber) VALUES('Ruda Śląska', '40123', 'Bukowa', 13, '3')",
                                null, transaction);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        try
                        {
                            Console.WriteLine("Exception thrown during inserting into table Address, try to rollback changes");
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
    }
}
