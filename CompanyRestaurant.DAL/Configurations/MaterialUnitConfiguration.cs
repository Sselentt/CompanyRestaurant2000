using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.DAL.Configurations
{
    public class MaterialUnitConfiguration : IEntityTypeConfiguration<MaterialUnit>
    {
        public void Configure(EntityTypeBuilder<MaterialUnit> builder)
        {
            builder.HasKey(mu => mu.ID); // BaseEntity'den gelen Id'yi anahtar olarak kullanır.

            builder.Property(mu => mu.Unit).IsRequired(); // Birim adı zorunlu bir alan.
            builder.Property(mu => mu.Description); // Açıklama zorunlu değil.

            // Material ile ilişki kurulumu
            builder.HasMany(mu => mu.Materials)
                   .WithOne(m => m.MaterialUnit)
                   .HasForeignKey(m => m.MateriUnitId); // Material sınıfında MaterialUnit'a referans veren ForeignKey


            // Seed Data
            builder.HasData(SeedMaterialUnitData());

        }

        public List<MaterialUnit> SeedMaterialUnitData()
        {
            List<MaterialUnit> materialUnits = new List<MaterialUnit>()
        {
             new MaterialUnit { ID = 1, Unit = "Kilogram", Description = "Test Kilogram" },
            new MaterialUnit { ID = 2, Unit = "Gram",Description = "Test Gram" }
        };
            return materialUnits;
        }
    }
}
