using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.PaymentVM
{
    public class PaymentViewModel
    {
        public decimal Amount { get; set; } // Ödeme tutarı
        public PaymentType PaymentType { get; set; } // Ödeme tipi
        [Display(Name = "Ödeme Tarihi")]
        public DateTime PaymentDate { get; set; } // Ödeme tarihi
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
    }
}
