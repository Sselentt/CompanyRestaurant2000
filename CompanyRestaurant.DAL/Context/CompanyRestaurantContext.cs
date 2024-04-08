using CompanyRestaurant.DAL.Configurations;
using CompanyRestaurant.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyRestaurant.DAL.Context
{
    public class CompanyRestaurantContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public CompanyRestaurantContext()
        {

        }

        public CompanyRestaurantContext(DbContextOptions<CompanyRestaurantContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Current> Currents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialPrice> MaterialPrices { get; set; }
        public DbSet<MaterialUnit> MaterialUnits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; } //yeni eklendi
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }  //yeni eklendi
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeMaterial> RecipeMaterials { get; set; }
        public DbSet<Rezervation> Rezervations { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; } //yeni eklendi
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<UnitStock> UnitStocks { get; set; }
       
     



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //Bir metot kendi görevinin üzerine ek bir şey yapmak istiyorsa polymorphism durumda önce kendi görevi yazılıy(Buradaki base görevi) sonra diger görevler eklenir :)


            //AppUser
            builder.ApplyConfiguration(new AppUserConfiguration());

            //AppRole
            builder.ApplyConfiguration(new AppRoleConfiguration());

            //AppUserRole
            builder.ApplyConfiguration(new AppUserRoleConfiguration());

            //Category
            builder.ApplyConfiguration(new CategoryConfiguration());

            //Current
            builder.ApplyConfiguration(new CurrentConfiguration());

            //Customer
            builder.ApplyConfiguration(new CustomerConfiguration());

            //Employee
            builder.ApplyConfiguration(new  EmployeeConfiguration());

            //Material
            builder.ApplyConfiguration(new MaterialConfiguration());

            //MaterialPrice
            builder.ApplyConfiguration(new MaterialPriceConfiguration());

            //MaterialUnit
            builder.ApplyConfiguration(new MaterialUnitConfiguration());

            //Order
            builder.ApplyConfiguration(new OrderConfiguration());

            //Payment
            builder.ApplyConfiguration(new PaymentConfiguration());

            //PerformanceReview
            builder.ApplyConfiguration(new PerformanceReviewConfiguration());

            //Product
            builder.ApplyConfiguration(new ProductConfiguration());
           
            //ProductOrder
            builder.ApplyConfiguration(new ProductOrderConfiguration());

            //Recipe
            builder.ApplyConfiguration(new RecipeConfiguration());

            //RecipeMaterial
            builder.ApplyConfiguration(new RecipeMaterialConfiguration());

            //Rezervation
            builder.ApplyConfiguration(new RezervationConfiguration());

            //StockMovement
            builder.ApplyConfiguration(new StockMovementConfiguration());

            //Supplier
            builder.ApplyConfiguration(new SupplierConfiguration());

            //Table
            builder.ApplyConfiguration(new TableConfiguration());

            //UnitStock
            builder.ApplyConfiguration(new UnitStockConfiguration());

           
           

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer
     ("server=DESKTOP-GB1SNRD\\SQLEXPRESS;database=CompanyRestaurantNew2024;Trusted_Connection=True;TrustServerCertificate=True;");
            // ("Server=localhost,1433;Database=NewCompany;User=sa;Password=Gfb1907*;TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
