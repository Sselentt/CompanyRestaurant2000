using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.CategoryVM
{
    public class CategoryViewModel
    {
        public int Id { get; set; } // Kategori ID'si

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; } // Kategori adı

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Kategori açıklaması

        // Opsiyonel: Eğer kategoriye ait ürün sayısını göstermek isterseniz
        [Display(Name = "Ürün Sayısı")]
        public int ProductCount { get; set; } // Bu kategoriye ait ürün sayısı
        [Display(Name ="Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name ="Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }
}
