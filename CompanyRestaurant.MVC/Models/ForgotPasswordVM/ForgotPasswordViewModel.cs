using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ForgotPasswordVM
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
