using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyRestaurant.DAL.Configurations
{
    public class PerformanceReviewConfiguration : IEntityTypeConfiguration<PerformanceReview>
    {
        public void Configure(EntityTypeBuilder<PerformanceReview> builder)
        {
            // PerformanceReview ID'si için anahtar yapılandırması
            builder.HasKey(pr => pr.ID);

            // Employee ile ilişki yapılandırması
            builder.HasOne(pr => pr.Employee)
                   .WithMany(e => e.PerformanceReviews)
                   .HasForeignKey(pr => pr.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade); // Çalışan silindiğinde, ilişkili performans değerlendirmeleri de silinsin

            // Değerlendirme tarihi, satış toplamı, sipariş sayısı, müşteri memnuniyeti ve notlar için yapılandırma
            builder.Property(pr => pr.ReviewDate).IsRequired();
            builder.Property(pr => pr.SalesTotal).HasColumnType("decimal(18, 2)");
            builder.Property(pr => pr.OrderCount).IsRequired();
            builder.Property(pr => pr.CustomerSatisfaction).HasColumnType("decimal(18, 2)");
            builder.Property(pr => pr.Notes).HasMaxLength(1000);

            // Seed data ekleme
            builder.HasData(SeedPerformanceReviewData());
        }

        private List<PerformanceReview> SeedPerformanceReviewData()
        {
            return new List<PerformanceReview>
        {
            new PerformanceReview
            {
                ID = 1,
                EmployeeId = 1,
                ReviewDate = new DateTime(2023, 11, 1),
                SalesTotal = 10000m,
                OrderCount = 50,
                CustomerSatisfaction = 8.5m,
                Notes = "Çok iyi performans, müşteri memnuniyeti yüksek."
            },
            new PerformanceReview
            {
                ID = 2,
                EmployeeId = 2,
                ReviewDate = new DateTime(2023, 11, 1),
                SalesTotal = 8000m,
                OrderCount = 40,
                CustomerSatisfaction = 8.0m,
                Notes = "İyi performans, daha fazla gelişme bekleniyor."
            }
        };
        }
    }

}
