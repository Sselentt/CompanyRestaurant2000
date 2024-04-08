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
    public class UnitStockConfiguration : IEntityTypeConfiguration<UnitStock>
    {
        public void Configure(EntityTypeBuilder<UnitStock> builder)
        {
            // Temel alanların yapılandırılması
            builder.Property(us => us.Stock).IsRequired();
            builder.Property(us => us.CriticalStock).IsRequired();
            builder.Property(us => us.MinimumStockLevel).IsRequired();

            // Material ile olan ilişki
            builder.HasOne(us => us.Material)
                   .WithOne(m => m.UnitStock)
                   .HasForeignKey<UnitStock>(us => us.MaterialID)
                   .OnDelete(DeleteBehavior.Restrict); // Malzeme silindiğinde, UnitStock korunur


            builder.HasData(
            new UnitStock { ID = 1, MaterialID = 1, Stock = 100, CriticalStock = 10, MinimumStockLevel = 5 },
            new UnitStock { ID = 2, MaterialID = 2, Stock = 200, CriticalStock = 20, MinimumStockLevel = 10 }
             );

        }

        
    }
}
