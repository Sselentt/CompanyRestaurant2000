using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class MaterialUnitRepository : BaseRepository<MaterialUnit>, IMaterialUnitRepository
    {
        public MaterialUnitRepository(CompanyRestaurantContext context) : base(context)
        {
        }
    }
}
