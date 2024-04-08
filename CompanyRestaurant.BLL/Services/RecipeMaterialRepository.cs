using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class RecipeMaterialRepository : BaseRepository<RecipeMaterial>, IRecipeMaterialRepository
    {
        public RecipeMaterialRepository(CompanyRestaurantContext context) : base(context)
        {
        }
    }
}
