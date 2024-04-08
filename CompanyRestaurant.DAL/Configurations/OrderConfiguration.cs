using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.ID);

            builder.Property(o => o.OrderName).IsRequired();
            builder.Property(o => o.Price).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(o => o.PaymentType).IsRequired(); // Enum olduğu için ekstra konfigürasyona ihtiyaç yok.

            // Employee ile ilişki
            builder.HasOne(o => o.Employee)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(o => o.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict); // Employee silindiğinde Order'ın silinmemesi için

            // Table ile ilişki
            builder.HasOne(o => o.Table)
                   .WithMany(t => t.Orders)
                   .HasForeignKey(o => o.TableId)
                   .OnDelete(DeleteBehavior.Restrict); // Table silindiğinde Order'ın silinmemesi için

            // Current ile ilişki
            builder.HasOne(o => o.Current)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CurrentId)
                   .OnDelete(DeleteBehavior.Restrict); // Current silindiğinde Order'ın silinmemesi için

            // ProductOrder ile ilişki
            builder.HasMany(o => o.ProductOrders)
                   .WithOne(po => po.Order)
                   .HasForeignKey(po => po.OrderId);

            // Payments ile ilişki
            builder.HasMany(o => o.Payments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.OrderId);

            // Seed Data
            builder.HasData(SeedOrderData());
        }

        private List<Order> SeedOrderData()
        {
            List<Order> orders = new List<Order>()
        {
            new Order
            {
                ID = 1,
                OrderName = "10. masa",
                Price = 500m,
                PaymentType = PaymentType.TL,
                TableId = 1,
                EmployeeId = 1, // EmployeeId için null değeri açıkça belirtildi
                CurrentId = 1 // Eğer CurrentId de isteğe bağlıysa, bu da null olarak belirtilebilir
            },
            new Order
            {
                ID = 2,
                OrderName = "8. masa",
                Price = 1000m,
                PaymentType = PaymentType.TL,
                TableId = 2,
                EmployeeId = 1, // EmployeeId için null değeri açıkça belirtildi
                CurrentId = 1, // Eğer CurrentId de isteğe bağlıysa, bu da null olarak belirtilebilir
                
            }
        };

            return orders;
        }
    }

}