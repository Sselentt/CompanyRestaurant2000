using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.MVC.Models.ProductVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Controllers
{
	public class MenuController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

		public MenuController(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productRepository.GetAllAsync();
			var productVMs = _mapper.Map<IEnumerable<ProductViewModel>>(products);
			return View(productVMs);
		}
	}
}
