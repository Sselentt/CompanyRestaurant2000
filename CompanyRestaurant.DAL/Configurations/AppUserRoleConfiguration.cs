using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Ignore(x => x.ID);
            // AppUserRole'un User ile olan ilişkisi
            builder.HasOne(x => x.User)
                   .WithMany(x => x.UserRoles)
                   .HasForeignKey(x => x.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde kullanıcıya ait roller de silinsin

            // AppUserRole'un Role ile olan ilişkisi
            builder.HasOne(x => x.Role)
                   .WithMany(x => x.UserRoles)
                   .HasForeignKey(x => x.RoleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);


            //Seed Data
            builder.HasData(SeedAppUserRoleData());
        }

        public List<AppUserRole> SeedAppUserRoleData()
        {
            List<AppUserRole> appuserroles = new List<AppUserRole>()
            {
                new AppUserRole{UserId=1,RoleId=1}

            };

            return appuserroles;
        }
    }
}
