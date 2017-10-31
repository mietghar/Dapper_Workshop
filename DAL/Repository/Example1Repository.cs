using DAL.ViewModel;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace DAL.Repository
{
    public class Example1Repository
    {
        private readonly string ConnectionString;

        public Example1Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public EmployeeDTO GetPerson()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.QueryFirstOrDefault<EmployeeDTO>("SELECT * FROM Employee");
            }
        }

        public IEnumerable<EmployeeDTO> GetPeople()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<EmployeeDTO>("SELECT * FROM Employee").ToList();
            }
        }
    }
}
