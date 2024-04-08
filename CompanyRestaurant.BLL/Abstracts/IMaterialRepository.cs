using CompanyRestaurant.Entities.Entities;
using System.Threading.Tasks;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<decimal> GetMaterialStockLevel(int materialId);
        Task<IEnumerable<Material>> GenerateStockReport();
        Task<IEnumerable<Material>> GetMaterialsForRecipe(int recipeId);
    }

}
