using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class PerformanceReviewRepository : BaseRepository<PerformanceReview>, IPerformanceReviewRepository
    {
        private readonly CompanyRestaurantContext _context;

        public PerformanceReviewRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PerformanceReview>> GetPerformanceReviewsByEmployee(int employeeId)
        {
            // Belirli bir çalışanın performans değerlendirmelerini getirir.
            return await _context.PerformanceReviews
                                 .Where(review => review.EmployeeId == employeeId)
                                 .ToListAsync();
        }
    }

}
