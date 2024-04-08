using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class RecipeMaterialConfiguration : IEntityTypeConfiguration<RecipeMaterial>
    {
        public void Configure(EntityTypeBuilder<RecipeMaterial> builder)
        {
            //Entity anahtarları ve zorunlu alanları yapılandırma
            builder.HasKey(rm => new { rm.RecipeID, rm.MaterialID }); //bileşik anahtar

            // Recipe ile ilişki kurulumu
            builder.HasOne(rm => rm.Recipe)
                   .WithMany(r => r.RecipeMaterials)
                   .HasForeignKey(rm => rm.RecipeID); // ForeignKey olarak RecipeID kullanılır.

            // Material ile ilişki kurulumu
            builder.HasOne(rm => rm.Material)
                   .WithMany(m => m.RecipeMaterial)
                   .HasForeignKey(rm => rm.MaterialID); // ForeignKey olarak MaterialID kullanılır.

            // Seed data eklemesi
            builder.HasData(
                new RecipeMaterial { RecipeID = 1, MaterialID = 1, Quantity = 500m },
                new RecipeMaterial { RecipeID = 2, MaterialID = 2, Quantity = 200m }
            );
        }

    }
}

