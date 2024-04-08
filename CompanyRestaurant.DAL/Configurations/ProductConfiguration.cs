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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            // Anahtar konfigürasyonu - BaseEntity'den gelen Id
            builder.HasKey(p => p.ID);

            // Zorunlu alanlar
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired();
            // Description alanı zorunlu olmadığı için bir konfigürasyona ihtiyaç yok.

            // Category ile ilişki - bir ürünün bir kategorisi olabilir
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products) // Bir kategorinin birden fazla ürünü olabilir
                   .HasForeignKey(p => p.CategoryId) // ForeignKey olarak CategoryId kullanılır
                   .OnDelete(DeleteBehavior.Restrict); // Category silindiğinde Product'ın silinmemesi için

            // Recipe ile ilişki - bir ürünün bir tarifi olabilir
            builder.HasOne(p => p.Recipe)
                   .WithMany() // Recipe tarafında bir koleksiyon yoksa bu şekilde bırakılır
                   .HasForeignKey(p => p.RecipeId) // ForeignKey olarak RecipeId kullanılır
                   .OnDelete(DeleteBehavior.Restrict); // Recipe silindiğinde Product'ın silinmemesi için

            // ProductOrder ile ilişki - bir ürün birden fazla sipariş detayına sahip olabilir
            builder.HasMany(p => p.ProductOrders)
                   .WithOne(po => po.Product) // Bir ProductOrder, bir Product ile ilişkilendirilir
                   .HasForeignKey(po => po.ProductId); // ForeignKey olarak ProductId kullanılır

            //Seed Data
            builder.HasData(SeedProductData());
        }



        public List<Product> SeedProductData()
        {
            List<Product> products = new List<Product>()
            {
                new Product{ID=1,ProductName="Basket Tabağı",Price=200,ImageUrl="/wwwroot/resim.jpg",Description="Tavuk,patates ve soslar",CategoryId=1},
                new Product{ID=2,ProductName="Karışık Pizza",Price = 250,ImageUrl = "/wwwroot/resim.jpg",Description="mantar,mısır,sos eşliğinde",CategoryId=2},
               
            };

            return products;
        }
    }
}
