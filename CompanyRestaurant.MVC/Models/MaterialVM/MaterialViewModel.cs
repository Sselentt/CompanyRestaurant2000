using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.MaterialVM
{
    public class MaterialViewModel
    {
        public int Id { get; set; } // Malzeme ID'si

        [Required(ErrorMessage = "Malzeme adı zorunludur.")]
        [Display(Name = "Malzeme Adı")]
        public string MaterialName { get; set; } // Malzeme adı

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; } // Malzeme fiyatı

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Display(Name = "Stok Miktarı")]
        public decimal UnitInStock { get; set; } // Stoktaki birim miktarı

        // Opsiyonel: Malzemenin birim tipi, malzeme kullanım alanları vs. gibi ek bilgiler
        [Display(Name = "Birim Tipi ID")]
        public int MateriUnitId { get; set; } // Malzeme birim tipi ID'si, dropdown list için

        [Display(Name = "Birim Tipi")]
        public string UnitName { get; set; } // Birim tipi adı, gösterim için

        // Malzeme ile ilişkili diğer bilgiler veya özellikler de eklenebilir.
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }

}
