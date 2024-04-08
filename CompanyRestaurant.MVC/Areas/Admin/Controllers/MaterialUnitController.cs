using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialUnitController : Controller
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        private readonly IMapper _mapper;

        public MaterialUnitController(IMaterialUnitRepository materialUnitRepository, IMapper mapper)
        {
            _materialUnitRepository = materialUnitRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialUnits = await _materialUnitRepository.GetAllAsync();
            return View(materialUnits);
        }

        public IActionResult Create()
        {
            return View();
        }

       

    }
}
