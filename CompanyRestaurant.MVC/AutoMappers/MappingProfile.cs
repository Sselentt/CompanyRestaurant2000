using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.AppRoleVM;
using CompanyRestaurant.MVC.Models.AppUserVM;
using CompanyRestaurant.MVC.Models.CategoryVM;
using CompanyRestaurant.MVC.Models.CurrentVM;
using CompanyRestaurant.MVC.Models.CustomerVM;
using CompanyRestaurant.MVC.Models.EmployeeVM;
using CompanyRestaurant.MVC.Models.MaterialPriceVM;
using CompanyRestaurant.MVC.Models.MaterialVM;
using CompanyRestaurant.MVC.Models.OrderVM;
using CompanyRestaurant.MVC.Models.PaymentVM;
using CompanyRestaurant.MVC.Models.PerformanceReviewVM;
using CompanyRestaurant.MVC.Models.ProductOrderVM;
using CompanyRestaurant.MVC.Models.ProductVM;
using CompanyRestaurant.MVC.Models.RecipeMaterialVM;
using CompanyRestaurant.MVC.Models.RecipeVM;
using CompanyRestaurant.MVC.Models.RezervationVM;
using CompanyRestaurant.MVC.Models.StockMovementVM;
using CompanyRestaurant.MVC.Models.SupplierVM;
using CompanyRestaurant.MVC.Models.TableVM;
using CompanyRestaurant.MVC.Models.UnitStockVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity'den ViewModel'e
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Current, CurrentViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            //CreateMap<Dashboard, DashboardViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<MaterialPrice, MaterialPriceViewModel>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PerformanceReview, PerformanceReviewViewModel>();
            CreateMap<ProductOrder, ProductOrderViewModel>();
            //CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductViewModel>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                                                   .ForMember(x => x.RecipeName, otp => otp.MapFrom(x => x.Recipe.Name)); //.ForMember(x => x.RecipeName, otp => otp.MapFrom(x => x.Recipe.Name)
            CreateMap<RecipeMaterial, RecipeMaterialViewModel>();
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Rezervation, RezervationViewModel>();
            CreateMap<StockMovement, StockMovementViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Table, TableViewModel>();
            CreateMap<UnitStock, UnitStockViewModel>();
            //CreateMap<RolePermissions, RolePermissionsViewModel>(); // Varsayılan bir RolePermissions entity'niz yoksa, bu satır düzenlenmelidir.
            //CreateMap<Permission, PermissionViewModel>(); // Varsayılan bir Permission entity'niz yoksa, bu satır düzenlenmelidir.

            // ViewModel'den Entity'e (Eğer gerekliyse)
            CreateMap<AppRoleViewModel, AppRole>();
            CreateMap<AppUserViewModel, AppUser>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<CurrentViewModel, Current>();
            CreateMap<CustomerViewModel, Customer>();
            //CreateMap<DashboardViewModel, Dashboard>(); // Dashboard için bir entity'niz yoksa, bu satırı kaldırın veya düzenleyin.
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<MaterialPriceViewModel, MaterialPrice>();
            CreateMap<MaterialViewModel, Material>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<PaymentViewModel, Payment>();
            CreateMap<PerformanceReviewViewModel, PerformanceReview>();
            CreateMap<ProductOrderViewModel, ProductOrder>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<RecipeMaterialViewModel, RecipeMaterial>();
            CreateMap<RecipeViewModel, Recipe>();
            CreateMap<RezervationViewModel, Rezervation>();
            CreateMap<StockMovementViewModel, StockMovement>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<TableViewModel, Table>();
            CreateMap<UnitStockViewModel, UnitStock>();
            //CreateMap<RolePermissionsViewModel, RolePermissions>(); // Varsayılan bir RolePermissions entity'niz yoksa, bu satır düzenlenmelidir.
            //CreateMap<PermissionViewModel, Permission>(); // Varsayılan bir Permission entity'niz yoksa, bu satır düzenlenmelidir.
        }
    }
}
