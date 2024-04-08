using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.StockMovementVM
{
    public class StockMovementViewModel
    {
        public int Id { get; set; } // Stok hareketinin benzersiz kimliği

        [Required(ErrorMessage = "Malzeme seçimi zorunludur.")]
        [Display(Name = "Malzeme ID")]
        public int MaterialId { get; set; } // İlgili malzemenin ID'si

        [Display(Name = "Malzeme Adı")]
        public string MaterialName { get; set; } // Kolaylık sağlaması için malzemenin adı

        [Required(ErrorMessage = "Miktar zorunludur.")]
        [Display(Name = "Miktar")]
        public decimal Quantity { get; set; } // Hareket miktarı

        [Required(ErrorMessage = "Hareket tipi zorunludur.")]
        [Display(Name = "Hareket Tipi")]
        public StockMovementType MovementType { get; set; } // Stok hareket tipi (Giriş veya Çıkış)

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Stok hareketiyle ilgili ek açıklamalar

        [Required(ErrorMessage = "Hareket tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Hareket Tarihi")]
        public DateTime MovementDate { get; set; } // Stok hareket tarihi
    }
}
