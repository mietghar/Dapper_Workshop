using DAL.ViewModel;
using Dapper;
using System.Linq;
using System.Data.SqlClient;

namespace DAL.Repository
{
    public class Example7Repository
    {
        private readonly string _connectionString;
        public Example7Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public object GetEmployeeAndItsAddress()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (var multipleQueryResult = connection.QueryMultiple("SELECT * FROM Employee WHERE AddressId = @id; SELECT * FROM Address WHERE AddressId = @Id", new { Id = 1 }))
                {
                    var employee = multipleQueryResult.Read<EmployeeDTO>().FirstOrDefault();
                    var employeeAddress = multipleQueryResult.Read<AddressDTO>().FirstOrDefault();

                    return (employee.AddressId == employeeAddress.Id) ? 
                    new
                    {
                        employee.Id,
                        employee.FirstName,
                        employee.LastName,
                        employee.AddressId,
                        employeeAddress.City,
                        employeeAddress.PostCode,
                        employeeAddress.Street,
                        employeeAddress.HouseNumber,
                        employeeAddress.LocalNumber
                    } : null;
                }
            }
        }
    }
}
