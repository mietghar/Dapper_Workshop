using Common.Utility;
using DAL.Repository;

namespace Dapper_Workshop
{
    public class DapperWorkshopInitializer
    {
        private readonly InitializationRepository Repository;

        public DapperWorkshopInitializer()
        {
            Repository = new InitializationRepository(ConnectionStore.ConnectionString);
        }

        public void InitializeDapperWorkshops()
        {
            Repository.InsertIntoPersonTable();
        }
    }
}
