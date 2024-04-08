using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public long TC { get; set; }
        public string Phone { get; set; }

        // İlişkisel Özellikler
        public virtual List<Order> Orders { get; set; }
        public virtual List<PerformanceReview> PerformanceReviews { get; set; } // Performans değerlendirmeleri

        // Kullanıcı hesabı ile ilişkilendirme
        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        // Constructor
        public Employee()
        {
            Orders = new List<Order>();
            PerformanceReviews = new List<PerformanceReview>();
        }
    }

}

//Uygulama Notları
//PerformanceReview entity'si, çalışanların performansını zaman içinde izlemek ve analiz etmek için kullanılır. Bu, yöneticilere çalışanların gelişim alanlarını belirlemek, güçlü yönlerini teşvik etmek ve performansa dayalı geribildirim sağlamak için değerli bir araç sunar.
//Performans değerlendirmeleri düzenli aralıklarla yapılabilir ve ReviewDate, değerlendirmenin yapıldığı tarihi belirtir. Bu, performans trendlerini ve gelişimini gözlemlemek için kullanılabilir.
//SalesTotal, OrderCount, ve CustomerSatisfaction gibi metrikler, performansın farklı yönlerini ölçmek için kullanılır. Bu metrikler, performans hedeflerinin belirlenmesi ve değerlendirilmesinde kritik öneme sahiptir.
//Notes alanı, değerlendirme sırasında özel gözlemler veya geliştirme önerileri için kullanılabilir.