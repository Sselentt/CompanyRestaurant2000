using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.MVC.Models.EmployeeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Controllers
{
    public class ChefController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public ChefController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        public async Task<IActionResult> Employees()
        {
            var employees = await _employeeRepository.GetAllEmployeePerformances();
            var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(employeeViewModels);
        }

    }
}
