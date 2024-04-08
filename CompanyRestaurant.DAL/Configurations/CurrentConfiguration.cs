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
    public class CurrentConfiguration : IEntityTypeConfiguration<Current>
    {
        public void Configure(EntityTypeBuilder<Current> builder)
        {
            // ID zaten BaseEntity'den geliyor ve otomatik olarak tanımlanıyor

            // Borç ve Alacak için decimal tipinde ve zorunlu alan tanımlaması
            builder.Property(c => c.Debit).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.Credit).IsRequired().HasColumnType("decimal(18,2)");

            // Cari Hesap Detayları
            builder.Property(c => c.AccountNumber).HasMaxLength(50);
            builder.Property(c => c.CompanyName).HasMaxLength(255);
            builder.Property(c => c.ContactName).HasMaxLength(255);
            builder.Property(c => c.ContactEmail).HasMaxLength(255);
            builder.Property(c => c.ContactPhone).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(500);
            builder.Property(c => c.TaxNumber).HasMaxLength(100);
            builder.Property(c => c.TaxOffice).HasMaxLength(255);

            // İlişkisel özellikler - Orders
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Current)
                   .HasForeignKey(o => o.CurrentId)
                   .OnDelete(DeleteBehavior.Cascade); // Cari hesap silindiğinde ilişkili siparişler de silinsin

            builder.HasOne(c => c.Customer)
                   .WithOne(c => c.CurrentAccount)
                   .HasForeignKey<Customer>(c => c.CurrentAccountId)
                   .OnDelete(DeleteBehavior.Cascade); // ya da iş modelinize uygun bir DeleteBehavior seçin

            // Seed Data için varsayılan Current kayıtları
            builder.HasData(SeedCurrentData());
        }

        public List<Current> SeedCurrentData()
        {
            List<Current> currents = new List<Current>()
         {
              new Current { ID = 1, AccountNumber = "123456", CompanyName = "Demo Şirketi", Debit = 0m, Credit = 0m, ContactName = "Ali Veli", ContactEmail = "aliveli@example.com", ContactPhone = "+900123456789", Address = "Demo Adres", TaxNumber = "1234567890", TaxOffice = "Demo Vergi Dairesi",CustomerId=1 },
             new Current { ID = 2, AccountNumber = "789012", CompanyName = "Örnek Şirketi", Debit = 0m, Credit = 0m, ContactName = "Ayşe Fatma", ContactEmail = "aysefatma@example.com", ContactPhone = "+900987654321", Address = "Örnek Adres", TaxNumber = "0987654321", TaxOffice = "Örnek Vergi Dairesi",CustomerId=2 }
         };

            return currents;
        }
    }
}
