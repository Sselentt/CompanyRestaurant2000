using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.MaterialVM;
using CompanyRestaurant.MVC.Models.RezervationVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin , Waiter")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class ReservationController : Controller
    {
        private readonly IRezervationRepository _rezervationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ReservationController(IRezervationRepository rezervationRepository, ITableRepository tableRepository,IAppUserRepository appUserRepository,ICustomerRepository customerRepository,UserManager<AppUser> userManager,IMapper mapper)
        {
            _rezervationRepository = rezervationRepository;
            _tableRepository = tableRepository;
            _appUserRepository = appUserRepository;
            _customerRepository = customerRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var rezervations = await _rezervationRepository.GetAllAsync();
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.Tables = tables;
            var appUsers = await _appUserRepository.GetAllAsync();
            ViewBag.AppUsers = appUsers;
            var customers = await _customerRepository.GetAllAsync();
            ViewBag.Customers = customers;
            var model = _mapper.Map<IEnumerable<RezervationViewModel>>(rezervations);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            var appUsers = await _appUserRepository.GetAllAsync();
            ViewBag.AppUsersSelect = new SelectList(appUsers, "ID", "AppUserId");
            var customers = await _customerRepository.GetAllAsync();
            ViewBag.CustomersSelect = new SelectList(customers, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RezervationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.AppUserName);

                var rezervation = _mapper.Map<Rezervation>(model);
                rezervation.AppUserId = user.Id;

                await _rezervationRepository.MakeReservation(rezervation);
                return RedirectToAction(nameof(Index));
            }
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            var appUsers = await _appUserRepository.GetAllAsync();
            ViewBag.AppUsersSelect = new SelectList(appUsers, "ID", "AppUserId");
            var customers = await _customerRepository.GetAllAsync();
            ViewBag.CustomersSelect = new SelectList(customers, "ID", "Name");
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _rezervationRepository.GetByIdAsync(id);
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
            await _rezervationRepository.UpdateAsync(reservation);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _rezervationRepository.GetByIdAsync(id);
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
            await _rezervationRepository.CancelReservation(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservation = await _rezervationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RezervationViewModel>(reservation);
            return View(model);
        }
    }
}
