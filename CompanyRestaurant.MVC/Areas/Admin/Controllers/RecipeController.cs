using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.RecipeVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize/*(Roles = "Admin")*/] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository,IProductRepository productRepository ,IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();
            ViewBag.Products = products;
            var model = _mapper.Map<IEnumerable<RecipeViewModel>>(recipes);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recipe = _mapper.Map<Recipe>(model);
                await _recipeRepository.CreateAsync(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RecipeViewModel>(recipe);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecipeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var recipe = _mapper.Map<Recipe>(model);
                await _recipeRepository.UpdateAsync(recipe);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<RecipeViewModel>(recipe));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var models = await _recipeRepository.GetByIdAsync(id);
            if (models == null)
            {
                return NotFound();
            }
            await _recipeRepository.DestroyAsync(models);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RecipeViewModel>(recipe);
            return View(model);
        }
        public async Task<IActionResult> CalculateCost(int id)
        {
            decimal cost = await _recipeRepository.CalculateRecipeCost(id);
            ViewBag.Cost = cost;
            return View("RecipeCost", new { RecipeId = id, Cost = cost }); // Veya uygun bir view model kullanarak
        }

        public async Task<IActionResult> DetailsWithMaterials(int id)
        {
            var recipe = await _recipeRepository.GetRecipeWithMaterials(id);
            if (recipe == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<RecipeViewModel>(recipe);
            return View("RecipeDetails", model);
        }
    }
}
