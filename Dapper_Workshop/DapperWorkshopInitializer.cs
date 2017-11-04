using Common.Utility;
using DAL.Repository;

namespace Dapper_Workshop
{
    public class DapperWorkshopInitializer
    {
        private readonly InitializationRepository _repository;

        public DapperWorkshopInitializer()
        {
            _repository = new InitializationRepository(ConnectionStore.ConnectionString);
        }

        public void InitializeDapperWorkshops() => _repository.Initialize();
        public void ReInitializeTable() => new PointsProcessor().ReInitializeTable();
    }
}
