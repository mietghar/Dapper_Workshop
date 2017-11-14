using Common.Utility;
using DAL.ViewModel;
using Dapper;
using Exercices.Exercices.Interface;
using System.Data.SqlClient;
using System.Linq;

namespace Exercices.Exercices.Exercice_5
{
    public class Exercice_5 : IExerciceChoice
    {
        /// <summary>
        /// Method should execute multimapping 1 to 1 query All of Employee Table and User Table where
        /// Employee.UserId is equal to User.Id
        /// </summary>
        /// <returns></returns>
        public object RunExercice()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionStore.ConnectionString))
            {
                var sql = "SELECT * FROM [Employee] Emp INNER JOIN [User] Usr ON Usr.UserId = Emp.UserId";
                var test = connection.Query<EmployeeDTO, UserDTO, EmployeeDTO>(sql, (x, y) => { x.UserId = y.UserId; return x; }, splitOn: "UserId").ToList();
                return test;
            }
        }
    }
}
