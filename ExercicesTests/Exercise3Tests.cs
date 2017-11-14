using Common.Utility;
using Exercices.Exercices.Exercice_3;
using NUnit.Framework;

namespace ExercicesTests
{
    public class Exercise3Tests
    {
        private readonly TestRepository _testRepostory;

        public Exercise3Tests()
        {
            _testRepostory = new TestRepository(ConnectionStore.ConnectionString);
        }

        [Test]
        public void run_third_exercice_should_update_one_address()
        {
            int oldNumberOfAddresses = _testRepostory.GetNumberOfAddresses();

            Exercice_3 thirdExercise = new Exercice_3();
            var numberOfUpdatedAddresses = thirdExercise.RunExercice();

            int newNumberOfAddresses = _testRepostory.GetNumberOfAddresses();

            Assert.AreEqual(oldNumberOfAddresses, newNumberOfAddresses);
            Assert.AreEqual(1, numberOfUpdatedAddresses);
        }
    }
}
