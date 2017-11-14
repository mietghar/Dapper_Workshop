using Common.Utility;
using Exercices.Exercices.Exercice_2;
using NUnit.Framework;

namespace ExercicesTests
{
    [TestFixture]
    public class Exercice2Tests
    {
        private readonly TestRepository _testRepostory;

        public Exercice2Tests()
        {
            _testRepostory = new TestRepository(ConnectionStore.ConnectionString);
        }

        [Test]
        public void run_exercise_second_should_add_one_address()
        {
            int oldNumberOfAddresses = _testRepostory.GetNumberOfAddresses();

            Exercice_2 secondExercise = new Exercice_2();
            var numberOfAddedAddresses = secondExercise.RunExercice();

            int newNumberOfAddresses = _testRepostory.GetNumberOfAddresses();

            Assert.AreEqual(oldNumberOfAddresses + 1, newNumberOfAddresses);
            Assert.AreEqual(1, numberOfAddedAddresses);
        }  
    }
}
