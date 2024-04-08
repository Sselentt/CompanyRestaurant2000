using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly CompanyRestaurantContext _context;

        public PaymentRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsForOrder(int orderId)
        {
            // Belirli bir sipariş ID'sine ait ödemeleri getirir.
            return await _context.Payments
                                 .Where(payment => payment.OrderId == orderId)
                                 .ToListAsync();
        }
    }

}
