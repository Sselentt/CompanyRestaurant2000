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
    public class RezervationConfiguration : IEntityTypeConfiguration<Rezervation>
    {
        public void Configure(EntityTypeBuilder<Rezervation> builder)
        {
            builder.HasKey(r => r.ID); // BaseEntity'den gelen Id'yi anahtar olarak kullanır.

            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Surname).IsRequired();
            builder.Property(r => r.PhoneNumber).IsRequired();
            builder.Property(r => r.Email).IsRequired();
            builder.Property(r => r.ReservationDate).IsRequired(); // Düzeltildi: Date -> ReservationDate
            builder.Property(r => r.Description);

            // StartTime ve EndTime yapılandırması
            builder.Property(r => r.StartTime).IsRequired(); // Eğer başlangıç saati zorunluysa
            builder.Property(r => r.EndTime).IsRequired(); // Eğer bitiş saati zorunluysa

            // AppUser ile ilişki kurulumu
            builder.HasOne(r => r.AppUser)
                   .WithMany(au => au.Rezervations)
                   .HasForeignKey(r => r.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade); // AppUser silindiğinde ilişkili rezervasyonlar da silinir

            // Table ile ilişki kurulumu
            builder.HasOne(r => r.Table)
                   .WithMany(t => t.Rezervations)
                   .HasForeignKey(r => r.TableId)
                   .OnDelete(DeleteBehavior.Restrict); // Table silindiğinde Rezervation silinmez

            // Customer ile ilişki kurulumu
            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Rezervations)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict); // Customer silindiğinde Rezervation silinmez

            //Seed Data
            builder.HasData(SeedRezervationData());
        }

        public List<Rezervation> SeedRezervationData()
        {
            List<Rezervation> rezervations = new List<Rezervation>()
              {
                 new Rezervation{ID=1, Name="Hülya", Surname="Budak", PhoneNumber="06598785496", Email="hulyabudak@gmail.com", ReservationDate=DateTime.Now.AddDays(1), StartTime=new TimeSpan(18, 30, 0), EndTime=new TimeSpan(20, 30, 0), Description="4 kişi", CustomerId=1, AppUserId=1, TableId=1},
            new Rezervation{ID=2, Name="Ayşe", Surname="Kolçak", PhoneNumber="06569854496", Email="aysekolcak@gmail.com", ReservationDate=DateTime.Now.AddDays(2), StartTime=new TimeSpan(19, 0, 0), EndTime=new TimeSpan(21, 0, 0), Description="2 kişi", CustomerId=2, AppUserId=2, TableId=2}
              };

            return rezervations;
        }

    }
}
