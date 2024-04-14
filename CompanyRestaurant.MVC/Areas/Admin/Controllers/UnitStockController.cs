using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.CategoryVM;
using CompanyRestaurant.MVC.Models.MaterialVM;
using CompanyRestaurant.MVC.Models.UnitStockVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UnitStockController : Controller
    {
        private readonly IUnitStockRepository _unitStockRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public UnitStockController(IUnitStockRepository unitStockRepository, IMaterialRepository materialRepository,IMapper mapper)
        {
            _unitStockRepository = unitStockRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> Index()
        {
            var unitStocks = await _unitStockRepository.GetAllAsync();
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.Materials = materials;
            var model = _mapper.Map<IEnumerable<UnitStockViewModel>>(unitStocks);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialId");
            return View(new UnitStockViewModel());
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
            var materialsReloaded = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materialsReloaded, "ID", "MaterialId");
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
