using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.TableVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Waiter")]
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableController(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var tables = await _tableRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<TableViewModel>>(tables);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                await _tableRepository.CreateAsync(table);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<TableViewModel>(table);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TableViewModel model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                await _tableRepository.UpdateAsync(table);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<TableViewModel>(table);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var models = await _tableRepository.GetByIdAsync(id);
            if (models == null)
            {
                return NotFound();
            }
            await _tableRepository.DestroyAsync(models);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<TableViewModel>(table);
            return View(model);
        }

    }
}
