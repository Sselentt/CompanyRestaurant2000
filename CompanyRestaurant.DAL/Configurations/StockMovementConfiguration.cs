using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.HasKey(sm => sm.ID); // BaseEntity'den gelen Id'yi anahtar olarak kullanır.

            builder.Property(sm => sm.MovementType).IsRequired(); // Stok hareket tipi zorunlu bir alan.
            builder.Property(sm => sm.Quantity).IsRequired().HasColumnType("decimal(18, 2)"); // Miktar, ondalık tipinde ve zorunlu.
            builder.Property(sm => sm.MaterialId).IsRequired(); // Malzeme ID'si zorunlu bir alan.
            builder.Property(sm => sm.Description); // Açıklama, zorunlu olmayabilir.
            builder.Property(sm => sm.MovementDate).IsRequired(); // Hareket tarihi zorunlu bir alan.

            // Material ile ilişki kurulumu
            builder.HasOne(sm => sm.Material)
                   .WithMany(m => m.StockMovements)
                   .HasForeignKey(sm => sm.MaterialId)
                   .OnDelete(DeleteBehavior.Cascade); // Malzeme silindiğinde ilişkili stok hareketleri de silinir.

            builder.HasData(SeedStockMovementData());
        }

        public List<StockMovement> SeedStockMovementData()
        {
            List<StockMovement> stockMovements = new List<StockMovement>()
             {
                 new StockMovement { ID = 1, MovementType = StockMovementType.Entry, Quantity = 200, MaterialId = 1, Description = "Başlangıç Stoku", MovementDate = DateTime.Now.AddDays(-30) },
                 new StockMovement { ID = 2, MovementType = StockMovementType.Exit, Quantity = 50, MaterialId = 1, Description = "Yemek Hazırlığı", MovementDate = DateTime.Now.AddDays(-25) },
                 // Daha fazla StockMovement verisi ekleyebilirsiniz.
             };

            return stockMovements;
        }
    }

}
