using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class MaterialPriceConfiguration : IEntityTypeConfiguration<MaterialPrice>
    {
        public void Configure(EntityTypeBuilder<MaterialPrice> builder)
        {
            builder.HasKey(mp => mp.ID); // BaseEntity'den gelen Id'yi anahtar olarak kullanır.

            builder.Property(mp => mp.Price).IsRequired(); // Fiyat zorunlu bir alan.
            builder.Property(mp => mp.Name).IsRequired(); // İsim zorunlu bir alan.
            builder.Property(mp => mp.Description); // Açıklama zorunlu değil.

            // Supplier ile ilişki kurulumu
            builder.HasOne(mp => mp.Supplier)
                   .WithMany(s => s.MaterialPrices) // Bir tedarikçinin birden fazla malzeme fiyatı olabilir.
                   .HasForeignKey(mp => mp.SupplierId) // ForeignKey olarak SupplierId kullanılır.
                   .OnDelete(DeleteBehavior.Restrict); // Supplier silindiğinde ilişkili MaterialPrice'ların silinmemesi için.

            // Material ile ilişki kurulumu
            builder.HasOne(mp => mp.Materials)
                   .WithOne(m => m.MaterialPrice)
                   .HasForeignKey<MaterialPrice>(mp => mp.MaterialId);


            builder.HasData(SeedMaterialPriceData());

        }

        public List<MaterialPrice> SeedMaterialPriceData()
        {
            List<MaterialPrice> materialPrices = new List<MaterialPrice>()
            {
                new MaterialPrice{ID=1, Name="Örnek Malzeme Fiyatı 1", Price=50m, Description="Açıklama", SupplierId=1,MaterialId=1},
                new MaterialPrice{ID=2, Name="Örnek Malzeme Fiyatı 2", Price=150m, Description="Açıklama", SupplierId=2,MaterialId=2},
            };

            return materialPrices;
        }

    }
}
