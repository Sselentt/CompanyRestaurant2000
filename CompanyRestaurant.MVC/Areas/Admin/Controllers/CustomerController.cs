using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.CustomerVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        // Müşterileri Listele
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            return View(model);
        }

        // Müşteri Detayları
        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CustomerViewModel>(customer);
            return View(model);
        }

        // Müşteri Ekleme
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                await _customerRepository.CreateAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Müşteri Düzenleme
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CustomerViewModel>(customer);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel model)
        {
            if (id != model.Id || !ModelState.IsValid)
            {
                return View(model);
            }

            var customer = _mapper.Map<Customer>(model);
            await _customerRepository.UpdateAsync(customer);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet] // HTTP GET metoduyla erişilmeli
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CustomerViewModel>(customer);
            return View(model);
        }

        [HttpPost] // HTTP POST metoduyla form gönderilecek
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerRepository.DestroyAsync(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
