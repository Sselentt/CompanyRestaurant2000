using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class MaterialPriceRepository : BaseRepository<MaterialPrice>, IMaterialPriceRepository
    {
        public MaterialPriceRepository(CompanyRestaurantContext context) : base(context)
        {
        }
    }
}
