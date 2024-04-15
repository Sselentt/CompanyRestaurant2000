using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.PerformanceReviewVM;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.EmployeeVM
{
    public class EmployeeViewModel
    {
        public int Id { get; set; } // Çalışanın benzersiz kimliği

        [Required(ErrorMessage = "Çalışanın adı zorunludur.")]
        [Display(Name = "Adı")]
        public string Name { get; set; } // Çalışanın adı

        [Required(ErrorMessage = "Çalışanın soyadı zorunludur.")]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; } // Çalışanın soyadı

        [Required(ErrorMessage = "Çalışanın unvanı zorunludur.")]
        [Display(Name = "Unvan")]
        public string Title { get; set; } // Çalışanın unvanı

        [Display(Name = "TC Kimlik No")]
        public long TC { get; set; } // Çalışanın TC kimlik numarası

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; } // Çalışanın telefon numarası

        public int? AppUserId { get; set; }
        [Display(Name = "Kullanıcı Hesabı")]
        public string UserName { get; set; } // İlişkilendirilmiş kullanıcı hesabının adı

        [Display(Name = "Performans Değerlendirme Sayısı")]
        public int PerformanceReviewCount{ get; set; } // Çalışana ait performans değerlendirme sayısı

        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?

        // Add the PerformanceReviews property here
        public List<PerformanceReviewViewModel> PerformanceReviews { get; set; }

        public EmployeeViewModel()
        {
            PerformanceReviews = new List<PerformanceReviewViewModel>(); // Initialize the list to prevent null reference errors
        }
    }

}
