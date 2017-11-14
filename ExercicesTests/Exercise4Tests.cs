using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utility;
using DAL.ViewModel;
using Exercices.Exercices.Exercise_3;
using Exercices.Exercise_4;
using NUnit.Framework;

namespace ExercicesTests
{
    public class Exercise4Tests
    {
        private readonly TestRepository _testRepostory;

        public Exercise4Tests()
        {
            _testRepostory = new TestRepository(ConnectionStore.ConnectionString);
        }

        [Test]
        public void run_fourth_exercice_should_select_addresses()
        {
            Exercice_4 fourthExercise = new Exercice_4();
            IEnumerable<AddressDTO> addressList = fourthExercise.RunExercice() as IEnumerable<AddressDTO>;
            var addressIds = fourthExercise.AddressesIds;

            var addressListFromTestRepository = _testRepostory.GetAddressByIds(addressIds);

            Assert.That(addressList.ToList(),  Is.EquivalentTo(addressListFromTestRepository.ToList()));
        }
    }
}
