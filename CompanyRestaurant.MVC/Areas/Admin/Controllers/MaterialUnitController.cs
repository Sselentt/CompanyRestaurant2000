using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.MaterialPriceVM;
using CompanyRestaurant.MVC.Models.MaterialUnitVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MaterialUnitController : Controller
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialUnitController(IMaterialUnitRepository materialUnitRepository, IMaterialRepository materialRepository,IMapper mapper)
        {
            _materialUnitRepository = materialUnitRepository;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialUnits = await _materialUnitRepository.GetAllAsync();
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.Materials = materials;
            var model = _mapper.Map<IEnumerable<MaterialUnitViewModel>>(materialUnits);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialId");
            return View(new MaterialUnitViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialUnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var materialUnit = _mapper.Map<MaterialUnit>(model);
                await _materialUnitRepository.CreateAsync(materialUnit);
                return RedirectToAction(nameof(Index));
            }
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialId");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialId");
            var materialUnit = await _materialUnitRepository.GetByIdAsync(id);
            if (materialUnit == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialUnitViewModel>(materialUnit);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialUnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var materialUnit = _mapper.Map<MaterialUnit>(model);
                await _materialUnitRepository.UpdateAsync(materialUnit);
                return RedirectToAction(nameof(Index));
            }
            var materials = await _materialRepository.GetAllAsync();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialId");
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var materialUnit = await _materialUnitRepository.GetByIdAsync(id);
            if (materialUnit == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialUnitViewModel>(materialUnit);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialUnit = await _materialUnitRepository.GetByIdAsync(id);
            if (materialUnit == null)
            {
                return NotFound();
            }

            await _materialUnitRepository.DestroyAsync(materialUnit);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var materialUnit = await _materialUnitRepository.GetByIdAsync(id);
            if (materialUnit == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialUnitViewModel>(materialUnit);
            return View(model);
        }

    }
}
