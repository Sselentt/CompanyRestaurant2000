using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class UnitStockRepository : BaseRepository<UnitStock>, IUnitStockRepository
    {
        private readonly CompanyRestaurantContext _context;

        public UnitStockRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateStockForMaterial(int materialId, int quantityChange)
        {
            var unitStock = await _context.UnitStocks.FirstOrDefaultAsync(us => us.MaterialID == materialId);
            if (unitStock != null)
            {
                unitStock.Stock += quantityChange; // Stok miktarını güncelle
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Unit stock for material not found");
            }
        }

        public async Task UpdateStockForProduct(int productId, int quantityChange)
        {
            // Ürünle ilgili doğrudan stok güncellemesi yapmak yerine,
            // ürünün reçetesine bağlı malzemelerin stoklarını güncellemeyi düşünebilirsiniz.
            // Bu, malzeme bazlı stok yönetimi yapıyorsanız mantıklı olacaktır.
            var product = await _context.Products
                                        .Include(p => p.Recipe)
                                        .ThenInclude(r => r.RecipeMaterials)
                                        .FirstOrDefaultAsync(p => p.ID == productId);

            if (product != null && product.Recipe != null)
            {
                foreach (var recipeMaterial in product.Recipe.RecipeMaterials)
                {
                    var materialStock = await _context.UnitStocks.FirstOrDefaultAsync(us => us.MaterialID == recipeMaterial.MaterialID);
                    if (materialStock != null)
                    {
                        // Ürün miktarı ve reçetede belirtilen malzeme miktarını kullanarak stok güncellemesi yapın
                        materialStock.Stock -= (int)(quantityChange * recipeMaterial.Quantity);

                    }
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Product or its recipe not found");
            }
        }
    }

}
