using Common.Utility;
using DAL.ViewModel;
using Exercices.Exercices.Exercice_1;
using NUnit.Framework;
using System.Linq;

namespace ExercicesTests
{
    [TestFixture]
    public class Exercice1Tests
    {
        [Test]

        public void RunExerciceMethodShouldReturnEmployeeDTOTypeObject()
        {
            Exercice_1 _firstExercice = new Exercice_1();
            var _employee = _firstExercice.RunExercice();
            var _employeeType = _employee.GetType();

            Assert.AreEqual(typeof(EmployeeDTO), _employeeType);
        }

        [Test]
        public void RunExerciceMethodShouldReturnExactlyOneRealObjectFromEmployeeTableDapperDBWithAllEntityProperties()
        {
            Exercice_1 _firstExercice = new Exercice_1();
            EmployeeDTO _employee = _firstExercice.RunExercice() as EmployeeDTO;
            var _employeeList = new TestRepository(ConnectionStore.ConnectionString).GetAllEmployees();
            var _containsResult = _employeeList
                .Any(x => x.AddressId == _employee.AddressId &&
                x.Id == _employee.Id &&
                x.FirstName == _employee.FirstName &&
                x.LastName == _employee.LastName);

            Assert.IsTrue(_containsResult);
        }
    }
}
