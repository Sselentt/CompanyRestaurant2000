using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.PerformanceReviewVM
{
    public class PerformanceReviewViewModel
    {
        public int Id { get; set; } // Performans değerlendirmesinin benzersiz kimliği

        [Required(ErrorMessage = "Çalışan ID'si zorunludur.")]
        [Display(Name = "Çalışan ID")]
        public int EmployeeId { get; set; } // İlgili çalışanın ID'si

        [Display(Name = "Çalışan Adı")]
        public string EmployeeName { get; set; } // İlgili çalışanın adı

        [Required(ErrorMessage = "Değerlendirme tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Değerlendirme Tarihi")]
        public DateTime ReviewDate { get; set; } // Değerlendirme tarihi

        [Required(ErrorMessage = "Toplam satış miktarı zorunludur.")]
        [Display(Name = "Toplam Satış Miktarı")]
        public decimal SalesTotal { get; set; } // Toplam satış miktarı

        [Required(ErrorMessage = "Toplam sipariş sayısı zorunludur.")]
        [Display(Name = "Toplam Sipariş Sayısı")]
        public int OrderCount { get; set; } // Toplam sipariş sayısı

        [Range(1, 10, ErrorMessage = "Müşteri memnuniyeti 1 ile 10 arasında bir değer olmalıdır.")]
        [Display(Name = "Müşteri Memnuniyeti")]
        public decimal CustomerSatisfaction { get; set; } // Müşteri memnuniyeti (örneğin, 1-10 arası bir değer)

        [Display(Name = "Notlar")]
        public string Notes { get; set; } // Performansla ilgili notlar veya yorumlar
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }
}
