using CompanyRestaurant.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyRestaurant.IOC.DependecyResolvers

{
    public static class ContextService
    {
        public static IServiceCollection AddRestaurantDb(this IServiceCollection services)
        {
            //Provider
            var provider=services.BuildServiceProvider();

            //Configuration
            var configuration = provider.GetService<IConfiguration>();

            
            services.AddDbContextPool<CompanyRestaurantContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;

        }
    }
}