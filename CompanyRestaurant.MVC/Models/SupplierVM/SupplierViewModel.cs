using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.SupplierVM
{
    public class SupplierViewModel
    {
        public int Id { get; set; } // Tedarikçinin benzersiz kimliği

        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        [Display(Name = "Şirket Adı")]
        public string CompanyName { get; set; } // Tedarikçi şirketin adı

        [Required(ErrorMessage = "Şehir zorunludur.")]
        [Display(Name = "Şehir")]
        public string City { get; set; } // Tedarikçinin bulunduğu şehir

        [Required(ErrorMessage = "Adres zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; } // Tedarikçi adresi

        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; } // Tedarikçi e-posta adresi

        [Phone]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; } // Tedarikçi telefon numarası

        [Display(Name = "İletişim Kişisi")]
        public string ContactPerson { get; set; } // İletişim için sorumlu kişi
    }
}
