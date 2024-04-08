using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<decimal> CalculateRecipeCost(int recipeId);
        Task<Recipe> GetRecipeWithMaterials(int recipeId); // Bu, Recipe entity'sini veya ilgili türü döndürmelidir.
    }
}
