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
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(r => r.ID); // BaseEntity'den gelen Id'yi anahtar olarak kullanır.

            builder.Property(r => r.Name).IsRequired(); // İsim zorunlu bir alan.
            builder.Property(r => r.Serves).IsRequired(); // Porsiyon bilgisi zorunlu bir alan.
            builder.Property(r => r.PreparationTime).IsRequired(); // Hazırlık süresi zorunlu bir alan.
            builder.Property(r => r.CookingTime).IsRequired(); // Pişirme süresi zorunlu bir alan.
            builder.Property(r => r.Instructions).IsRequired(); // Hazırlama talimatları zorunlu bir alan.
            builder.Property(r => r.ImageUrl); // Reçetenin görseli, zorunlu olmayabilir.

            // Product ile ilişki kurulumu (Her reçetenin sadece bir ürünü olabilir)
            builder.HasOne(r => r.Product)
                   .WithOne(p => p.Recipe)
                   .HasForeignKey<Recipe>(r => r.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); // Ürün silindiğinde reçetenin silinmemesi için.

            // RecipeMaterial ile ilişki kurulumu (Bir reçetenin birden fazla malzemesi olabilir)
            builder.HasMany(r => r.RecipeMaterials)
                   .WithOne(rm => rm.Recipe)
                   .HasForeignKey(rm => rm.RecipeID);

            builder.HasData(SeedRecipeData());
        }

        // Seed Data
        private List<Recipe> SeedRecipeData()
        {
            List<Recipe> recipes = new List<Recipe>()
        {
            new Recipe { ID = 1, Name = "Örnek reçete 1", Serves = 5, PreparationTime = new TimeSpan(0, 23, 0), CookingTime = new TimeSpan(1, 0, 0), Instructions = "Tarif talimatları buraya gelecek...", ImageUrl = "örnek-url.jpg", ProductId = 1},
            new Recipe { ID = 2, Name = "Örnek reçete 2", Serves = 1, PreparationTime = new TimeSpan(0, 30, 0), CookingTime = new TimeSpan(2, 0, 0), Instructions = "Tarif talimatları buraya gelecek...", ImageUrl = "örnek-url.jpg", ProductId = 2} // ProductId'ye dikkat edin, her tarifin ilişkilendirildiği bir ürün olmalıdır
        };

            return recipes;
        }
    }
}
