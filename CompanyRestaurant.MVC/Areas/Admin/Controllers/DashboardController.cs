using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.MVC.Models.DashboardVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IRezervationRepository _rezervationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPerformanceReviewRepository _performanceReviewRepository;
        private readonly IEmployeeRepository _employeeRepository;

        // Kullanılan repository'lerin constructor üzerinden enjekte edilmesi
        public DashboardController(IOrderRepository orderRepository,
                                   IMaterialRepository materialRepository,
                                   IRezervationRepository rezervationRepository,
                                   IProductRepository productRepository,
                                   IPerformanceReviewRepository performanceReviewRepository,
                                   IEmployeeRepository employeeRepository)
        {
            _orderRepository = orderRepository;
            _materialRepository = materialRepository;
            _rezervationRepository = rezervationRepository;
            _productRepository = productRepository;
            _performanceReviewRepository = performanceReviewRepository;
            _employeeRepository = employeeRepository;

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel();

            // Toplam satış miktarı
            var orders = await _orderRepository.GetAllAsync();
            viewModel.TotalSales = orders.Sum(o => o.Price);

            // Bugünkü satış miktarı
            var today = DateTime.Today;
            viewModel.TodaySales = orders.Where(o => o.CreatedDate.Value.Date == today).Sum(o => o.Price);

            // Aktif rezervasyon sayısı
            var rezervations = await _rezervationRepository.GetAllAsync();
            viewModel.ActiveReservations = rezervations.Count(r => r.ReservationDate >= today);

            // Stokta azalan ürün sayısı
            var materials = await _materialRepository.GenerateStockReport();
            viewModel.LowStockProductsCount = materials.Count();

            // Toplam çalışan sayısı
            var totalEmployees = await _employeeRepository.GetAllAsync();
            viewModel.TotalEmployees = totalEmployees.Count();

            return View(viewModel);
        }
    }
}