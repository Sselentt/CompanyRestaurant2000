using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ResetPasswordVM
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ve şifre tekrarı uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
