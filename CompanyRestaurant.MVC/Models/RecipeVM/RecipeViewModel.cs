using CompanyRestaurant.MVC.Models.RecipeMaterialVM;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.RecipeVM
{
    public class RecipeViewModel
    {
        public int Id { get; set; } // Reçetenin benzersiz kimliği

        [Required(ErrorMessage = "Reçete adı zorunludur.")]
        [Display(Name = "Reçete Adı")]
        public string Name { get; set; } // Reçete adı

        [Required(ErrorMessage = "Porsiyon bilgisi gereklidir.")]
        [Display(Name = "Porsiyon Sayısı")]
        public int Serves { get; set; } // Kaç porsiyon olduğu

        [Required(ErrorMessage = "Hazırlık süresi gereklidir.")]
        [Display(Name = "Hazırlık Süresi")]
        public TimeSpan PreparationTime { get; set; } // Hazırlık süresi

        [Required(ErrorMessage = "Pişirme süresi gereklidir.")]
        [Display(Name = "Pişirme Süresi")]
        public TimeSpan CookingTime { get; set; } // Pişirme süresi

        [Display(Name = "Talimatlar")]
        public string Instructions { get; set; } // Hazırlanış talimatları

        [Display(Name = "Reçete Görseli URL")]
        public string ImageUrl { get; set; }  //Reçete resmi URL

        [Display(Name = "Ürün ID")]
        public int ProductId { get; set; } // Ürün ile ilişkilendirme

        // Reçete maliyeti gibi hesaplanabilir alanlar da ViewModel'e eklenebilir.
        [Display(Name = "Toplam Maliyet")]
        public decimal TotalCost { get; set; } // Toplam maliyet

        // Reçeteye ait malzemeleri tutacak bir koleksiyon
        //[Display(Name = "Malzemeler")]
        public List<RecipeMaterialViewModel> RecipeMaterials { get; set; }

        public RecipeViewModel()
        {
            RecipeMaterials = new List<RecipeMaterialViewModel>();
        }
    }
}
