using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class MaterialRepository : BaseRepository<Material>, IMaterialRepository
    {
        private readonly CompanyRestaurantContext _context;

        public MaterialRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> GetMaterialStockLevel(int materialId)
        {
            var material = await _context.Materials.FindAsync(materialId);
            return material != null ? material.UnitInStock : 0;
        }

        public async Task<IEnumerable<Material>> GenerateStockReport()
        {
            // Örnek olarak, stok miktarı 10'un altındaki malzemeleri filtreleyelim.
            // Gerçek bir senaryoda, bu eşik değeri bir konfigürasyon dosyasından veya kullanıcı girişinden alınabilir.



            //const decimal stockThreshold = 10;
            //return await _context.Materials
            //                      .Where(m => m.UnitInStock < stockThreshold)
            //                      .ToListAsync();

            return await _context.Materials.ToListAsync();
        }

        public async Task<IEnumerable<Material>> GetMaterialsForRecipe(int recipeId)
        {
            // Bu metod, belirli bir reçete için gerekli olan malzemelerin listesini döndürür.
            var materials = await _context.RecipeMaterials
                                           .Where(rm => rm.RecipeID == recipeId)
                                           .Include(rm => rm.Material)
                                           .Select(rm => rm.Material)
                                           .ToListAsync();
            return materials;
        }
    }
}
