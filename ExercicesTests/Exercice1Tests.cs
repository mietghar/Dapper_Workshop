using Common.Utility;
using DAL.ViewModel;
using Exercices.Exercices.Exercice_1;
using NUnit.Framework;

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
        public void RunExerciceMethodShouldReturnAtLeastOneRealObjectFromEmployeeTableDapperDBWithAllProperties()
        {
            Exercice_1 _firstExercice = new Exercice_1();
            var _employee = _firstExercice.RunExercice();
            var _expectedEmployee = new TestRepository(ConnectionStore.ConnectionString).GetAllEmployees();
        }
    }
}
