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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Temel alanların yapılandırılması
            builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Surname).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.TC).IsRequired();
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(20);

            // Siparişler ile ilişki kurulması
            builder.HasMany(e => e.Orders)
                   .WithOne(o => o.Employee)
                   .HasForeignKey(o => o.EmployeeId)
                   .OnDelete(DeleteBehavior.SetNull); // Çalışan silindiğinde, siparişlerdeki çalışan referansı null olarak ayarlanır

            // Performans değerlendirmeleri ile ilişki kurulması
            builder.HasMany(e => e.PerformanceReviews)
                   .WithOne(pr => pr.Employee)
                   .HasForeignKey(pr => pr.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade); // Çalışan silindiğinde, ilişkili performans değerlendirmeleri de silinir

            // Kullanıcı hesabı ile ilişkilendirme
            builder.HasOne(e => e.AppUser)
                   .WithOne(a => a.Employee)
                   .HasForeignKey<Employee>(e => e.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade); // Çalışan ile ilişkili kullanıcı hesabı da silinecek şekilde ayarlanır

            // Seed Data
            builder.HasData(SeedEmployeeData());
        }

        private List<Employee> SeedEmployeeData()
        {
            List<Employee> employees = new List<Employee>()
        {
            new Employee{ID = 1, Name="İlknur", Surname="Dursun", Title="Şef", TC=36254987452L, Phone="06598754123", AppUserId = 1}, // AppUserId ilişkilendirildi
            new Employee{ID = 2, Name="Veli", Surname="İlev", Title="Kasiyer", TC=65987412365L, Phone="65978523614", AppUserId = 2}, // AppUserId ilişkilendirildi
            // AppUserId 3 numaralı kullanıcıyı Employee ile ilişkilendirmek için kullanılabilir. Örneğin: new Employee{ID = 3, Name="Murat", Surname="Gider", Title="Garson", TC=98756321458L, Phone="06983215478", AppUserId = 3}
        };

            return employees;
        }
    }

}
