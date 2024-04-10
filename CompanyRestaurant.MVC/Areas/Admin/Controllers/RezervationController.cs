using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.RezervationVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Waiter")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class ReservationController : Controller
    {
        private readonly IRezervationRepository _reservationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public ReservationController(IRezervationRepository reservationRepository, ITableRepository tableRepository,IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _reservationRepository.GetAllAsync();
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.Tables = tables;
            var model = _mapper.Map<IEnumerable<RezervationViewModel>>(reservations);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            return View(new RezervationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RezervationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reservation = _mapper.Map<Rezervation>(model);
                await _reservationRepository.MakeReservation(reservation);
                return RedirectToAction(nameof(Index));
            }
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RezervationViewModel>(reservation);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RezervationViewModel model)
        {
            if (id != model.Id || !ModelState.IsValid)
            {
                return View(model);
            }

            var reservation = _mapper.Map<Rezervation>(model);
            await _reservationRepository.UpdateAsync(reservation);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RezervationViewModel>(reservation);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _reservationRepository.CancelReservation(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RezervationViewModel>(reservation);
            return View(model);
        }
    }
}
