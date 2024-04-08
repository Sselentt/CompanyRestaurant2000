using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface ITableRepository : IRepository<Table>
    {
        Task OpenTable(int tableId);
        Task CloseTable(int tableId);
        Task<IEnumerable<Table>> GetAllTables();
        Task<IEnumerable<Table>> GetTableUsageReport(DateTime startDate, DateTime endDate); // ViewModel yerine doğrudan entity dönüş tipi.
    }
}


