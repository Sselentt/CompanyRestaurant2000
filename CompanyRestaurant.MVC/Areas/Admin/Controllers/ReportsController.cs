using AutoMapper;
using ClosedXML.Excel;
using CompanyRestaurant.BLL.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRezervationRepository _rezervationRepository;
        private readonly IStockMovementRepository _stockMovementRepository;

        public ReportsController(IOrderRepository orderRepository,
                                 IMaterialRepository materialRepository,
                                 IEmployeeRepository employeeRepository,
                                 IRezervationRepository rezervationRepository,
                                 IStockMovementRepository stockMovementRepository,
                                 IMapper mapper)
        {
            _orderRepository = orderRepository;
            _materialRepository = materialRepository;
            _employeeRepository = employeeRepository;
            _rezervationRepository = rezervationRepository;
            _stockMovementRepository = stockMovementRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Example: Sales Report by Date Range
        public async Task<IActionResult> SalesReportByDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDateRange(startDate, endDate);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sales Report");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Order ID";
                worksheet.Cell(currentRow, 2).Value = "Order Name";
                worksheet.Cell(currentRow, 3).Value = "Price";
                worksheet.Cell(currentRow, 4).Value = "Payment Type";
                worksheet.Cell(currentRow, 5).Value = "Order Date";

                foreach (var order in orders)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.ID;
                    worksheet.Cell(currentRow, 2).Value = order.OrderName;
                    worksheet.Cell(currentRow, 3).Value = order.Price;
                    worksheet.Cell(currentRow, 4).Value = order.PaymentType.ToString();
                    // order.CreatedDate'in null olup olmadığını kontrol edin
                    if (order.CreatedDate.HasValue)
                    {
                        // order.CreatedDate null değilse, değeri formatlayarak string'e dönüştürün
                        worksheet.Cell(currentRow, 5).Value = order.CreatedDate.Value.ToString("yyyy-MM-dd HH:mm");
                    }
                    else
                    {
                        // order.CreatedDate null ise, hücreye boş bir string veya alternatif bir değer atayın
                        worksheet.Cell(currentRow, 5).Value = ""; // veya "N/A", "Tarih Yok" gibi alternatif bir değer
                    }

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SalesReport.xlsx");
                }
            }
        }

        // Example: Stock Report
        public async Task<IActionResult> StockReport()
        {
            var materials = await _materialRepository.GenerateStockReport();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Stock Report");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Material ID";
                worksheet.Cell(currentRow, 2).Value = "Material Name";
                worksheet.Cell(currentRow, 3).Value = "Unit In Stock";
                worksheet.Cell(currentRow, 4).Value = "Price";

                foreach (var material in materials)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = material.ID;
                    worksheet.Cell(currentRow, 2).Value = material.MaterialName;
                    worksheet.Cell(currentRow, 3).Value = material.UnitInStock;
                    worksheet.Cell(currentRow, 4).Value = material.Price;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StockReport.xlsx");
                }
            }
        }

        // Example: Employee Performance Report
        public async Task<IActionResult> EmployeePerformanceReport()
        {
            var employees = await _employeeRepository.GetAllEmployeePerformances();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employee Performance Report");
                var currentRow = 1;
                // Sütun başlıkları
                worksheet.Cell(currentRow, 1).Value = "Employee ID";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "Surname";
                worksheet.Cell(currentRow, 4).Value = "Performance Reviews Count";
                worksheet.Cell(currentRow, 5).Value = "Average Customer Satisfaction";

                foreach (var employee in employees)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = employee.ID;
                    worksheet.Cell(currentRow, 2).Value = employee.Name;
                    worksheet.Cell(currentRow, 3).Value = employee.Surname;
                    worksheet.Cell(currentRow, 4).Value = employee.PerformanceReviews.Count;

                    // Örnek olarak, müşteri memnuniyetinin ortalamasını hesaplıyoruz.
                    var averageSatisfaction = employee.PerformanceReviews.Any() ? employee.PerformanceReviews.Average(pr => pr.CustomerSatisfaction) : 0;
                    worksheet.Cell(currentRow, 5).Value = averageSatisfaction;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeePerformanceReport.xlsx");
                }
            }
        }
        public async Task<IActionResult> ReservationReport()
        {
            var reservations = await _rezervationRepository.GetAllAsync(); // Assuming GetAllAsync exists or similar
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reservations Report");
                var currentRow = 1;
                // Sütun başlıkları
                worksheet.Cell(currentRow, 1).Value = "Reservation ID";
                worksheet.Cell(currentRow, 2).Value = "Customer Name";
                worksheet.Cell(currentRow, 3).Value = "Customer Surname";
                worksheet.Cell(currentRow, 4).Value = "Phone Number";
                worksheet.Cell(currentRow, 5).Value = "Email";
                worksheet.Cell(currentRow, 6).Value = "Reservation Date";
                worksheet.Cell(currentRow, 7).Value = "Start Time";
                worksheet.Cell(currentRow, 8).Value = "End Time";
                worksheet.Cell(currentRow, 9).Value = "Description";

                foreach (var reservation in reservations)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = reservation.ID;
                    worksheet.Cell(currentRow, 2).Value = reservation.Name;
                    worksheet.Cell(currentRow, 3).Value = reservation.Surname;
                    worksheet.Cell(currentRow, 4).Value = reservation.PhoneNumber;
                    worksheet.Cell(currentRow, 5).Value = reservation.Email;
                    worksheet.Cell(currentRow, 6).Value = reservation.ReservationDate.ToString("yyyy-MM-dd");
                    worksheet.Cell(currentRow, 7).Value = reservation.StartTime.ToString(@"hh\:mm");
                    worksheet.Cell(currentRow, 8).Value = reservation.EndTime.ToString(@"hh\:mm");
                    worksheet.Cell(currentRow, 9).Value = reservation.Description;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReservationsReport.xlsx");
                }
            }
        }

        public async Task<IActionResult> StockMovementReport(DateTime startDate, DateTime endDate)
        {
            var movements = await _stockMovementRepository.GetStockMovementsForPeriod(startDate, endDate);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Stock Movements Report");
                var currentRow = 1;
                // Sütun başlıkları
                worksheet.Cell(currentRow, 1).Value = "Movement ID";
                worksheet.Cell(currentRow, 2).Value = "Material Name";
                worksheet.Cell(currentRow, 3).Value = "Movement Type";
                worksheet.Cell(currentRow, 4).Value = "Quantity";
                worksheet.Cell(currentRow, 5).Value = "Movement Date";
                worksheet.Cell(currentRow, 6).Value = "Description";

                foreach (var movement in movements)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = movement.ID;
                    worksheet.Cell(currentRow, 2).Value = movement.MaterialId; // Örnek malzeme adı, gerçek veri yapınıza göre değiştirilmelidir.
                    worksheet.Cell(currentRow, 3).Value = movement.MovementType.ToString();
                    worksheet.Cell(currentRow, 4).Value = movement.Quantity;
                    worksheet.Cell(currentRow, 5).Value = movement.MovementDate.ToString("yyyy-MM-dd HH:mm");
                    worksheet.Cell(currentRow, 6).Value = movement.Description;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "StockMovementsReport.xlsx");
                }
            }
        }

    }
}
