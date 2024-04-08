using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.BLL.Services
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        private readonly CompanyRestaurantContext _context;

        public RecipeRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task<decimal> CalculateRecipeCost(int recipeId)
        {
            var recipeMaterials = await _context.RecipeMaterials
                                                .Include(rm => rm.Material)
                                                .Where(rm => rm.RecipeID == recipeId)
                                                .ToListAsync();

            decimal totalCost = recipeMaterials.Sum(rm => rm.Material.Price * rm.Quantity);

            return totalCost;
        }

        public async Task<Recipe> GetRecipeWithMaterials(int recipeId)
        {
            var recipe = await _context.Recipes
                                       .Include(r => r.RecipeMaterials)
                                           .ThenInclude(rm => rm.Material)
                                       .FirstOrDefaultAsync(r => r.ID == recipeId);

            return recipe;
        }
    }
}
