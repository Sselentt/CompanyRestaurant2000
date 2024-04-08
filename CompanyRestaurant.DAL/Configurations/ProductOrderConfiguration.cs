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
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {


            builder.HasKey(x => x.ID);

            // Product ile ilişki kurulumu
            builder.HasOne(po => po.Product)
                   .WithMany(p => p.ProductOrders)
                   .HasForeignKey(po => po.ProductId); // ForeignKey olarak ProductId kullanılır.

            // Order ile ilişki kurulumu
            builder.HasOne(po => po.Order)
                   .WithMany(o => o.ProductOrders)
                   .HasForeignKey(po => po.OrderId); // ForeignKey olarak OrderId kullanılır.

            //Seed Data
            builder.HasData(SeedProductOrderData());
        }

        public List<ProductOrder> SeedProductOrderData()
        {
            List<ProductOrder> productorders = new List<ProductOrder>()
            {
                new ProductOrder{ID=1,ProductId=1,OrderId=1},
                new ProductOrder{ID=2,ProductId=2,OrderId=2}

            };

            return productorders;
        }
    }
}
