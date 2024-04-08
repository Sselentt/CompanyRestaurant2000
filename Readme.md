# Company Restaurant projesi Ntier mimarisine uygun yapýlmýþtýr.

## Burada proje ile ilgili detaylar yer alýcaktýr. 

## CompanyRestaurant.Entities;
Projede kullanýlmasý gereken entitylerin dahil edildiði katmandýr. 


## CompanyRestaurant.DAL
Katmanýn sahip olmasý gereken kütüphaneler;
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

Context veritabanýný temsil eder.
Configuration entitilerin hangi kurallar dahilinde oluþturulmasý gerektiðini barýndýrýr.

## CompanyRestaurant.BLL
categoryrepository ve categoryservices oluþturuyoruz çünkü kategoriye lazým olan kurallarý tanýmlamak için bu da solidin "Ý" si kuralýna uymuþ oluruz.
