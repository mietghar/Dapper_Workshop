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
            _addressIds = Enumerable.Range(1, 2).ToArray();
            // _addressesIds = list of addresses ids
        }


        /// <summary>
        /// Method should execute select from addresses using list parameters
        /// </summary>
        public object RunExercice()
        {
            string query = "Select * from [Address] where AddressId IN @AddressesIds";

            using (SqlConnection connection = new SqlConnection(ConnectionStore.ConnectionString))
            {
                return connection.Query<AddressDTO>(query, new { @AddressesIds = _addressIds }).ToList();
            }
        }

        public IEnumerable<int> AddressIds => _addressIds;
    }
}
