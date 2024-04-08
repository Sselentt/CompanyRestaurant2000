using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.CurrentVM
{
    public class CurrentViewModel
    {
        public int Id { get; set; } // Cari Hesap ID'si

        [Required(ErrorMessage = "Hesap numarası zorunludur.")]
        [Display(Name = "Hesap Numarası")]
        public string AccountNumber { get; set; } // Hesap Numarası

        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        [Display(Name = "Şirket Adı")]
        public string CompanyName { get; set; } // Şirket Adı (Bireysel müşteriler için boş bırakılabilir)

        [Display(Name = "İletişim Adı")]
        public string ContactName { get; set; } // İletişim Adı

        [EmailAddress]
        [Display(Name = "İletişim E-Postası")]
        public string ContactEmail { get; set; } // İletişim E-postası

        [Phone]
        [Display(Name = "İletişim Telefonu")]
        public string ContactPhone { get; set; } // İletişim Telefonu

        [Display(Name = "Adres")]
        public string Address { get; set; } // Adres

        [Display(Name = "Vergi Numarası")]
        public string TaxNumber { get; set; } // Vergi Numarası (Bireysel müşteriler için boş bırakılabilir)

        [Display(Name = "Vergi Dairesi")]
        public string TaxOffice { get; set; } // Vergi Dairesi (Bireysel müşteriler için boş bırakılabilir)

        // Cari hesabın bakiyesi gibi hesaplanan alanlar da ViewModel içerisinde yer alabilir
        [Display(Name = "Bakiye")]
        public decimal Balance { get; set; } // Borç - Alacak hesaplaması sonucu bakiye

        // Opsiyonel olarak, cari hesaba ait siparişlerin listesi veya sayısını göstermek isteyebilirsiniz
        // Bu bilgi, kullanıcı arayüzünde ilgili cari hesap detaylarında ek bilgi olarak sunulabilir
        [Display(Name = "Sipariş Sayısı")]
        public int OrderCount { get; set; } // Bu cari hesaba ait sipariş sayısı
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }
}
