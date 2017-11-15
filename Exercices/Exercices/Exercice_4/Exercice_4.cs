using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Common.Utility;
using Dapper;
using DAL.ViewModel;
using Exercices.Exercices.Interface;

namespace Exercices.Exercices.Exercice_4
{
    public class Exercice_4 : IExerciceChoice
    {
        private readonly IEnumerable<int> _addressIds;

        /// <summary>
        /// Constructor should initialize list of parameters
        /// </summary>
        public Exercice_4()
        {
            // _addressesIds = list of addresses ids
        }


        /// <summary>
        /// Method should execute select from addresses using list parameters
        /// </summary>
        public object RunExercice()
        {
            string query = "Select * from [Address] where Id IN @AddressesIds";

            return 0;
        }

        public IEnumerable<int> AddressIds => _addressIds;
    }
}
