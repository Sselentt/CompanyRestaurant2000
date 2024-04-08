using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class PerformanceReview : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime ReviewDate { get; set; } // Değerlendirme tarihi
        public decimal SalesTotal { get; set; } // Toplam satış miktarı
        public int OrderCount { get; set; } // Toplam sipariş sayısı
        public decimal CustomerSatisfaction { get; set; } // Müşteri memnuniyeti (örneğin, 1-10 arası bir değer)
        public string Notes { get; set; } // Performansla ilgili notlar veya yorumlar
    }
}
