using DAL.ViewModel;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.Repository
{
    public class RepositoryExample_1
    {
        private readonly string ConnectionString;

        public RepositoryExample_1(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Example_1ViewModel GetPerson()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Example_1ViewModel>("SELECT * FROM Person").FirstOrDefault();
            }
        }

        public IEnumerable<Example_1ViewModel> GetPeople()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Example_1ViewModel>("SELECT * FROM Person").ToList();
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
