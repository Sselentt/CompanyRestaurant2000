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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Temel alanların yapılandırılması
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(255);
            builder.Property(c => c.Description).HasMaxLength(500);

            // Rezervasyonlar ile ilişki kurulması
            builder.HasMany(c => c.Rezervations)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // Müşteri silindiğinde ilişkili rezervasyonlar da silinsin

            // Cari hesap ile ilişki kurulması
            builder.HasOne(c => c.CurrentAccount)
                   .WithOne(c => c.Customer)
                   .HasForeignKey<Current>(c => c.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade); // ya da iş modelinize uygun bir DeleteBehavior seçin


            // Seed Data - Örnek Müşteri Kayıtları
            builder.HasData(SeedCustomerData());
        }

        public List<Customer> SeedCustomerData()
        {
            List<Customer> customers = new List<Customer>()
        {
             new Customer { ID = 1, Name = "Ahmet", Surname = "Yılmaz", Phone = "+905551112233", Email = "ahmetyilmaz@example.com", Description = "İlk müşteri" ,CurrentAccountId=1},
            new Customer { ID = 2, Name = "Merve", Surname = "Kaya", Phone = "+905559998877", Email = "mervekaya@example.com", Description = "Sık müşteri" ,CurrentAccountId=2}
        };
            return customers;
        }
    }
}
