using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.UnitStockVM
{
    public class UnitStockViewModel
    {
        public int Id { get; set; } // Stok biriminin benzersiz kimliği

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; } // Mevcut stok miktarı

        [Required(ErrorMessage = "Kritik stok seviyesi zorunludur.")]
        [Display(Name = "Kritik Stok Seviyesi")]
        public int CriticalStock { get; set; } // Kritik stok seviyesi

        [Required(ErrorMessage = "Minimum stok seviyesi zorunludur.")]
        [Display(Name = "Minimum Stok Seviyesi")]
        public int MinimumStockLevel { get; set; } // Minimum stok seviyesi

        [Display(Name = "Kritik Seviyeye Ulaşıldı mı?")]
        public bool IsCriticalLevelReached { get; set; } // Kritik stok seviyesine ulaşılıp ulaşılmadığı
    }
}
