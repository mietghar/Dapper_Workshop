using System.Collections.Generic;
using System.Linq;
using Common.Utility;
using DAL.ViewModel;
using Exercices.Exercise_4;
using NUnit.Framework;

namespace ExercicesTests
{
    class AddressDTOComparer : Comparer<AddressDTO>
    {
        public override int Compare(AddressDTO x, AddressDTO y)
        {
            int result = 0;
            for(int i=0; i < typeof(AddressDTO).GetProperties().Count(); i++)
            {
                result += x.GetType().GetProperties()[i].GetValue(x).GetHashCode().CompareTo(y.GetType().GetProperties()[i].GetValue(y).GetHashCode());
            }
            return result;
        }
    }

    [TestFixture]
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

            CollectionAssert.AreEqual(addressList.OrderBy(x => x.AddressId), addressListFromTestRepository.OrderBy(x => x.AddressId), new AddressDTOComparer());
        }
    }
}
