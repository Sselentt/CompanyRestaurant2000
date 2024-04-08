using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.CompanyName).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Address).IsRequired().HasMaxLength(500);
            builder.Property(s => s.City).HasMaxLength(255); // City alanı için yapılandırma
            builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Phone).IsRequired().HasMaxLength(20);
            builder.Property(s => s.ContactPerson).HasMaxLength(255);

            // MaterialPrices ile olan ilişki
            builder.HasMany(s => s.MaterialPrices)
                   .WithOne(mp => mp.Supplier)
                   .HasForeignKey(mp => mp.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade); // Tedarikçi silindiğinde ilişkili Malzeme Fiyatları da silinsin

            //Seed Data
            builder.HasData(SeedSupplierData());
        }

        public List<Supplier> SeedSupplierData()
        {
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier{ID=1,CompanyName="Bahçeden",Address="Kadıköy",Email="bahceden@gmail",Phone="02169874512",ContactPerson="Kadir",City="istanbul"},
                new Supplier{ID=2,CompanyName="Nestle",Address="Ataşehir",Email="nestle@gmail.com",Phone="02169852314",ContactPerson="Zerrin",City = "istanbul"},
            };

            return suppliers;
        }
    }
}
