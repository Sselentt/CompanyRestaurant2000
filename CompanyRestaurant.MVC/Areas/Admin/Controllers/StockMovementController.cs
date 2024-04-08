using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.StockMovementVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class StockMovementController : Controller
    {
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public StockMovementController(IStockMovementRepository stockMovementRepository, IMapper mapper)
        {
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var stockMovements = await _stockMovementRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<StockMovementViewModel>>(stockMovements);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new StockMovementViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockMovementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entry = _mapper.Map<StockMovement>(model);
                if (model.MovementType == StockMovementType.Entry)
                {
                    await _stockMovementRepository.RecordStockEntry(entry);
                }
                else
                {
                    await _stockMovementRepository.RecordStockExit(entry);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Filter(DateTime startDate, DateTime endDate)
        {
            var movements = await _stockMovementRepository.GetStockMovementsForPeriod(startDate, endDate);
            var model = _mapper.Map<IEnumerable<StockMovementViewModel>>(movements);
            return View("Index", model);
        }
    }
}
