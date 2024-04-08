using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.CategoryVM;
using CompanyRestaurant.MVC.Models.UnitStockVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UnitStockController : Controller
    {
        private readonly IUnitStockRepository _unitStockRepository;
        private readonly IMapper _mapper;

        public UnitStockController(IUnitStockRepository unitStockRepository, IMapper mapper)
        {
            _unitStockRepository = unitStockRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var unitStocks = await _unitStockRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<UnitStockViewModel>>(unitStocks);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                var unitStock = _mapper.Map<UnitStock>(model);
                await _unitStockRepository.CreateAsync(unitStock);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var unitStock = await _unitStockRepository.GetByIdAsync(id);
            if (unitStock == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UnitStockViewModel>(unitStock);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UnitStockViewModel model)
        {
            if (ModelState.IsValid)
            {
                var unitStock = _mapper.Map<UnitStock>(model);
                await _unitStockRepository.UpdateAsync(unitStock);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var unitStock = await _unitStockRepository.GetByIdAsync(id);
            if (unitStock == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UnitStockViewModel>(unitStock);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitStock = await _unitStockRepository.GetByIdAsync(id);
            if (unitStock == null)
            {
                return NotFound();
            }

            await _unitStockRepository.DestroyAsync(unitStock);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var unitStock = await _unitStockRepository.GetByIdAsync(id);
            if (unitStock == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<UnitStockViewModel>(unitStock);
            return View(model);
        }






    }
}
