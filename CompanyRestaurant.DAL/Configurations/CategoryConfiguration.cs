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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(255); // CategoryName için gereklilik ve maksimum uzunluk tanımı

            builder.Property(x => x.Description);
            // Description için özel bir yapılandırma gerekmez çünkü zaten nullable

            // Product ile olan ilişki
            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade); // Kategori silindiğinde ilişkili ürünler de silinsin


            //Seed Data
            builder.HasData(SeedCategoryData());
        }


        public List<Category> SeedCategoryData()
        {
            List<Category> categories = new List<Category>()
            {
                new Category{ID=1,CategoryName="Atıştırmalık"},
                new Category{ID=2,CategoryName="Pizza"},
            };

            return categories;
        }
    }
}
