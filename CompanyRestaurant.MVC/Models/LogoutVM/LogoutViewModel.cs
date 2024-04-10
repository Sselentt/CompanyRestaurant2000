using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.LogoutVM
{
    public class LogoutViewModel
    {
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
