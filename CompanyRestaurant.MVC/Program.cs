using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.IOC.DependecyResolvers;
using CompanyRestaurant.MVC.AutoMappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(typeof(MappingProfile));


// Eðer kullanýcaksanýz, ASP.NET Core Identity yapýlandýrmasý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = true;
    options.Password.RequiredLength = 2;
})
.AddEntityFrameworkStores<CompanyRestaurantContext>()
.AddDefaultTokenProviders();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("tr-TR") }; // Örnek olarak Türkiye için
    options.DefaultRequestCulture = new RequestCulture("tr-TR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//bu ayar biz admin paneli içine accountcontrolleri koyduðumuz için var.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Account/Login"; // Giriþ yapýlmamýþsa yönlendirilecek yol
    options.AccessDeniedPath = new PathString("/Admin/Account/AccessDenied"); // Eriþim reddedildiðinde yönlendirilecek yol
    options.LogoutPath = "/Admin/Account/Logout"; // Çýkýþ iþlemi için yol (isteðe baðlý)
});

//AddDbContext
builder.Services.AddRestaurantDb();

//AddRepositories
builder.Services.AddRepositoryService();

builder.Services.AddControllersWithViews(options =>
{
    // Global olarak Authorize attribute'unu tüm controller'lara uygula
    //options.Filters.Add(new AuthorizeFilter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.Run();
