using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Ignore(x => x.ID);
            builder.HasMany(u => u.UserRoles)
                       .WithOne(ur => ur.User)
                       .HasForeignKey(ur => ur.UserId);

            builder.HasMany(u => u.Rezervations)
                   .WithOne(r => r.AppUser) // Rezervation sınıfında AppUser'a referans veren property burada belirtilmelidir.
                   .HasForeignKey(r => r.AppUserId);

            builder.HasOne(u => u.Employee)
               .WithOne(e => e.AppUser)
               .HasForeignKey<Employee>(e => e.AppUserId);

            //Seed Data
            builder.HasData(SeedAppUserData());
        }

        public List<AppUser> SeedAppUserData()
        {
            List<AppUser> appusers = new List<AppUser>()
            {
                new AppUser{Id=1,UserName="Selen",PhoneNumber="05414741089",Email="sselentt@gmail.com",EmployeeId=1},
                new AppUser{Id=2,UserName="İrem",PhoneNumber="05698751164",Email="iiremtt23@gmail.com",EmployeeId=2}

            };

            return appusers;
        }
    }
}
