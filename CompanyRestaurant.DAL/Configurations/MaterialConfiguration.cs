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
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {

            builder.HasKey(m => m.ID);

            builder.Property(m => m.MaterialName).IsRequired();
            builder.Property(m => m.Price).IsRequired();
            builder.Property(m => m.UnitInStock).IsRequired();

            // RecipeMaterial ile ilişki
            builder.HasMany(m => m.RecipeMaterial)
                   .WithOne(rm => rm.Material)
                   .HasForeignKey(rm => rm.MaterialID);

            // UnitStock ile ilişki (Tek bir UnitStock ile ilişkilendirilmiş)
            builder.HasOne(m => m.UnitStock)
                   .WithOne(us => us.Material)
                   .HasForeignKey<UnitStock>(us => us.MaterialID);

            // MaterialUnit ile ilişki
            builder.HasOne(m => m.MaterialUnit)
                   .WithMany(mu => mu.Materials)
                   .HasForeignKey(m => m.MateriUnitId);

            // MaterialPrice ile ilişki (Tek bir MaterialPrice ile ilişkilendirilmiş, varsayılan olarak bu ilişki tek-tek kabul edilir)
            builder.HasOne(m => m.MaterialPrice)
                   .WithOne(mp => mp.Materials)
                   .HasForeignKey<MaterialPrice>(mp => mp.MaterialId);

            // StockMovement ile ilişkinin yapılandırılması
            builder.HasMany(m => m.StockMovements)
                   .WithOne(sm => sm.Material)
                   .HasForeignKey(sm => sm.MaterialId)
                   .OnDelete(DeleteBehavior.Cascade); // Material silindiğinde, ilişkili StockMovements da silinir

            // Seed Data
            builder.HasData(SeedMaterialData());
        }

        // Seed Data
        public List<Material> SeedMaterialData()
        {
            List<Material> materials = new List<Material>()
            {
                 new Material { ID = 1, MaterialName = "Patates", Price = 50m, UnitInStock = 50, MateriUnitId = 1, UnitStockID = 1 ,MaterialPriceId=1},
                 new Material { ID = 2, MaterialName = "Sucuk", Price = 150m, UnitInStock = 100, MateriUnitId = 2, UnitStockID = 2 , MaterialPriceId=2}
            };

            return materials;
        }
    }
}
