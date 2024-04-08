using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.RecipeMaterialVM
{
    public class RecipeMaterialViewModel
    {
        public int MaterialId { get; set; }
        [Display(Name = "Malzeme Adı")]
        public string MaterialName { get; set; } // Malzemenin adı

        [Required(ErrorMessage = "Malzeme miktarı gereklidir.")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; } // Gereken malzeme miktarı
    }
}
