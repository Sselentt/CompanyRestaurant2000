using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // BaseEntity'den gelen ID özelliğini kullanacak şekilde yapılandırma
            builder.HasKey(p => p.ID);

            // Ödeme miktarı ve ödeme türü için yapılandırma
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(p => p.PaymentType).IsRequired();

            // İlişkisel yapılandırmalar
            builder.HasOne(p => p.Order)
                   .WithMany(o => o.Payments)
                   .HasForeignKey(p => p.OrderId)
                   .OnDelete(DeleteBehavior.Cascade); // Sipariş silindiğinde ilişkili ödemeler de silinir

            // Ödeme açıklaması ve ödeme tarihi için yapılandırma
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.PaymentDate).IsRequired();

            // Seed data eklenmesi
            builder.HasData(PaymentSeed.GetPayments());
        }

        public class PaymentSeed
        {
            public static List<Payment> GetPayments()
            {
                return new List<Payment>
        {
            new Payment
            {
                ID = 1,
                OrderId = 1,
                Amount = 500m, // Sipariş tutarıyla aynı varsayıyoruz
                PaymentType = PaymentType.TL,
                PaymentDate = DateTime.Now,
                Description = "İlk sipariş için ödeme"
            },
            new Payment
            {
                ID = 2,
                OrderId = 2,
                Amount = 1000m, // Sipariş tutarıyla aynı varsayıyoruz
                PaymentType = PaymentType.TL,
                PaymentDate = DateTime.Now,
                Description = "İkinci sipariş için ödeme"
            }
        };
            }
        }

    }
}
