﻿using DAL.ViewModel;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace ExercicesTests
{
    public class TestBase
    {

    }

    public class TestRepository
    {
        private readonly string ConnectionString;

        public TestRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<EmployeeDTO>("SELECT * FROM Employee").ToList();
            }
        }

        public IEnumerable<EmployeeDTO> GetAllAddresses()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<EmployeeDTO>("SELECT * FROM Address").ToList();
            }
        }

        public int GetNumberOfAddresses()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirst<int>("SELECT COUNT(*) FROM Address");
            }
        }
    }
}
