using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.MaterialPriceVM
{
    public class MaterialPriceViewModel
    {
        public int Id { get; set; } // Malzeme Fiyatı ID'si

        [Required(ErrorMessage = "Malzeme adı zorunludur.")]
        [Display(Name = "Malzeme Adı")]
        public string MaterialName { get; set; } // İlişkili malzemenin adı

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // Malzemenin fiyatı

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Fiyatlandırma ile ilgili açıklama

        // Opsiyonel: Malzemenin tedarikçi bilgileri
        public int SupplierId { get; set; }
        [Display(Name = "Tedarikçi Adı")]
        public string SupplierName { get; set; } // İlişkilendirilmiş tedarikçinin adı

        // Opsiyonel: Malzeme ile ilişkili diğer bilgiler veya özellikler de eklenebilir.
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }

}
