using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class AppRoleRepository:BaseRepository<AppRole>,IAppRoleRepository
    {
        public AppRoleRepository(CompanyRestaurantContext context):base(context)
        {
                
        }
    }
}
