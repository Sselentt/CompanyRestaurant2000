using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Common.MailSender.Abstract;
using CompanyRestaurant.Common.MailSender.Concrate;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyRestaurant.IOC.DependecyResolvers
{
	public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICurrentRepository, CurrentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialPriceRepository, MaterialPriceRepository>();
            services.AddScoped<IMaterialUnitRepository, MaterialUnitRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IRecipeMaterialRepository, RecipeMaterialRepository>();
            services.AddScoped<IRezervationRepository, RezervationRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IUnitStockRepository, UnitStockRepository>();
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}
