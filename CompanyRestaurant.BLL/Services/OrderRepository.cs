using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly CompanyRestaurantContext _context;

        public OrderRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            // Verilen tarih aralığında oluşturulan siparişleri getirir.
            return await _context.Orders
                                 .Where(order => order.CreatedDate >= startDate && order.CreatedDate <= endDate)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            
            return await _context.Orders
                                 .Where(order => order.CreatedDate >= startDate && order.CreatedDate <= endDate)
                                 .ToListAsync();
        }
    }

}
