using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.CategoryVM;
using CompanyRestaurant.MVC.Models.MaterialPriceVM;
using CompanyRestaurant.MVC.Models.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Accountant")]
    public class MaterialPriceController : Controller
    {
        private readonly IMaterialPriceRepository _materialPriceRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialPriceController(IMaterialPriceRepository materialPriceRepository,ISupplierRepository supplierRepository, IMaterialRepository materialRepository,IMapper mapper)
        {
            _materialPriceRepository = materialPriceRepository;
            _supplierRepository = supplierRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialPrices = await _materialPriceRepository.GetAllAsync();
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.Suppliers = suppliers;
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.Materials = materials;
            var model = _mapper.Map<IEnumerable<MaterialPriceViewModel>>(materialPrices);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            return View(new MaterialPriceViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialPriceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var materialPrice = _mapper.Map<MaterialPrice>(model);
                await _materialPriceRepository.CreateAsync(materialPrice);
                return RedirectToAction(nameof(Index));
            }

            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            var materialPrice = await _materialPriceRepository.GetByIdAsync(id);
            if (materialPrice == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialPriceViewModel>(materialPrice);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialPriceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var materialPrice = _mapper.Map<MaterialPrice>(model);
                await _materialPriceRepository.UpdateAsync(materialPrice);
                return RedirectToAction(nameof(Index));
            }
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "Name");
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var materialPrice = await _materialPriceRepository.GetByIdAsync(id);
            if (materialPrice == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialPriceViewModel>(materialPrice);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialPrice = await _materialPriceRepository.GetByIdAsync(id);
            if (materialPrice == null)
            {
                return NotFound();
            }

            await _materialPriceRepository.DestroyAsync(materialPrice);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var materialPrice = await _materialPriceRepository.GetByIdAsync(id);
            if (materialPrice == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialPriceViewModel>(materialPrice);
            return View(model);
        }
    }
}
