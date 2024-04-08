using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IUnitStockRepository : IRepository<UnitStock>
    {
        Task UpdateStockForMaterial(int materialId, int quantityChange);
        Task UpdateStockForProduct(int productId, int quantityChange);
    }
}
