using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class AppUserRoleRepository:BaseRepository<AppUserRole>,IAppUserRoleRepository
    {
        public AppUserRoleRepository(CompanyRestaurantContext context):base(context) 
        {
                
        }
    }
}
