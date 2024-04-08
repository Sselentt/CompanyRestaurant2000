using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class AppUserRepository :BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(CompanyRestaurantContext context):base(context) 
        {

        }
    }
}
