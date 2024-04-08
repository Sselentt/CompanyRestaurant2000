using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Order>> GenerateSalesReport(DateTime startDate, DateTime endDate); // Dönüş tipi entity olarak değiştirildi.
    }
}
