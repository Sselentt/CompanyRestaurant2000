using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Ignore(x => x.ID);
            builder.HasMany(ar => ar.UserRoles)
                 .WithOne(ur => ur.Role)
                 .HasForeignKey(ur => ur.RoleId)
                 .IsRequired();

            //Seed Data
            builder.HasData(SeedAppRoleData());
        }

        public List<AppRole> SeedAppRoleData()
        {
            List<AppRole> approles = new List<AppRole>()
            {
                new AppRole{Id=1,Name="Admin"},
                new AppRole{Id=2,Name="Customer"}
                

            };

            return approles;
        }

    }
}
