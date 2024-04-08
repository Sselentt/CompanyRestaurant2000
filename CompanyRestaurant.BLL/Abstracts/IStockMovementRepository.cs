using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IStockMovementRepository : IRepository<StockMovement>
    {
        Task RecordStockEntry(StockMovement entry); // ViewModel yerine doğrudan entity alacak şekilde güncellendi.
        Task RecordStockExit(StockMovement exit); // ViewModel yerine doğrudan entity alacak şekilde güncellendi.
        Task<IEnumerable<StockMovement>> GetStockMovementsForPeriod(DateTime startDate, DateTime endDate);
    }
}

