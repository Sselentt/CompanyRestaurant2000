using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        private readonly CompanyRestaurantContext _context;
        public EmployeeRepository(CompanyRestaurantContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeePerformances()
        {
            // Performans değerlendirmelerini Employee ile birlikte çekmek için
            // Örnek olarak, Employee ve PerformanceReview modelleriniz arasında bir ilişki varsa:
            var employeesWithPerformance = await _context.Employees
                                                          .Include(emp => emp.PerformanceReviews)
                                                          .ToListAsync();

            return employeesWithPerformance;
        }
    }
}
