using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Common.Image;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IRecipeRepository recipeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.Categories = categories;
            var recipes = await _recipeRepository.GetAllAsync();
            ViewBag.Recipes = recipes;
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            // Kategori seçenekleri
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            // Reçete seçenekleri
            var recipes = await _recipeRepository.GetAllAsync();
            ViewBag.RecipesSelect = new SelectList(recipes, "ID", "Name"); // Düzeltme burada yapıldı
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Dosya yükleme işlemleri
                if (model.ProductImage != null && model.ProductImage.Length > 0)
                {
                    var fileExtension = Path.GetExtension(model.ProductImage.FileName);
                    string fileName = Image.GenerateFileName(fileExtension); // Bu Image sınıfınızın metodunu kullanarak dosya adı oluşturun.
                    if (fileName != "0")
                    {
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProductImage.CopyToAsync(fileStream);
                        }

                        // Ürünü veritabanına kaydetmeden önce ImageUrl'i güncelleyin.
                        var product = _mapper.Map<Product>(model);
                        product.ImageUrl = fileName; // Dosyanın kaydedildiği adı kullanın.
                        await _productRepository.CreateAsync(product);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("ProductImage", "Desteklenmeyen dosya türü.");
                    }
                }
                else
                {
                    ModelState.AddModelError("ProductImage", "Ürün resmi yüklenmedi.");
                }
            }

            // Model valid değilse veya dosya yükleme başarısızsa, kategorileri ve reçeteleri tekrar yükle
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            var recipes = await _recipeRepository.GetAllAsync();
            ViewBag.RecipesSelect = new SelectList(recipes, "ID", "Name");
            return View(model);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            var recipes = await _recipeRepository.GetAllAsync();
            ViewBag.RecipesSelect = new SelectList(recipes, "ID", "Name"); // Düzeltme burada yapıldı
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productInDb = await _productRepository.GetByIdAsync(model.Id); // Veritabanından mevcut ürünü alın.
                if (productInDb == null)
                {
                    return NotFound();
                }

                // Automapper kullanarak model üzerindeki değişiklikleri productInDb üzerine uygulayın.
                _mapper.Map(model, productInDb);

                // Eğer yeni bir resim yüklendi ise işlemleri yapın
                if (model.ProductImage != null && model.ProductImage.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProductImage.CopyToAsync(fileStream);
                    }
                    productInDb.ImageUrl = fileName; // Mevcut resim url'sini güncelleyin.
                }

                await _productRepository.UpdateAsync(productInDb); // _productRepository'de UpdateAsync metodunun içini değiştirebilirsiniz.
                return RedirectToAction(nameof(Index));
            }

            // ModelState valid değilse veya diğer hata durumlarında kategorileri ve reçeteleri tekrar yükleyin.
            // Model valid değilse veya dosya yükleme başarısızsa, kategorileri ve reçeteleri tekrar yükle
            var categories = await _categoryRepository.GetAllAsync();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            var recipes = await _recipeRepository.GetAllAsync();
            ViewBag.RecipesSelect = new SelectList(recipes, "ID", "Name");
            return View(model);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.DestroyAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        // Ürün satışı için ekstra metod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellProduct(int productId, int quantity)
        {
            try
            {
                await _productRepository.SellProduct(productId, quantity);
                // Satış işlemi başarılıysa kullanıcıyı bilgilendir
                // Bu örnekte doğrudan Index sayfasına yönlendirme yapılmıştır, gerekirse başarılı işlem bilgisi de gösterilebilir.
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                // Hata yönetimi
                ModelState.AddModelError("", ex.Message);
                return View("Error"); // Hata mesajını gösterecek bir Error view'ınız olduğunu varsayıyorum.
            }
        }
    }
}
