using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.AppUserVM
{
    public class AppUserViewModel
    {
        public string Id { get; set; } // Kullanıcının benzersiz kimliği
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; } // Kullanıcı adı

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; } // Kullanıcının e-posta adresi

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; } // Kullanıcının telefon numarası

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kullanıcının aktiflik durumu

        [Display(Name = "Roller")]
        public List<string> Roles { get; set; } // Kullanıcının rolleri (Eğer rol ataması yapılacaksa)

        // Eğer kullanıcı oluştururken şifre de belirlemek isterseniz:
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; } // Kullanıcı şifresi

        public AppUserViewModel()
        {
            Roles = new List<string>();
        }
    }
}
