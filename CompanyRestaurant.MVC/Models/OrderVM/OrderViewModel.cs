using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.PaymentVM;
using CompanyRestaurant.MVC.Models.ProductOrderVM;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.OrderVM
{
    public class OrderViewModel
    {
        public int Id { get; set; } // Siparişin benzersiz kimliği

        [Required(ErrorMessage = "Sipariş adı zorunludur.")]
        [Display(Name = "Sipariş Adı")]
        public string OrderName { get; set; } // Sipariş adı

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } // Siparişin toplam fiyatı

        [Required(ErrorMessage = "Ödeme tipi zorunludur.")]
        [Display(Name = "Ödeme Tipi")]
        public PaymentType PaymentType { get; set; } // Ödeme tipi

        [Display(Name = "Çalışan ID")]
        public int? EmployeeId { get; set; } // İlgili çalışanın ID'si (Opsiyonel)

        [Display(Name = "Masa ID")]
        public int? TableId { get; set; } // İlgili masanın ID'si (Opsiyonel)

        [Display(Name = "Cari Hesap ID")]
        public int? CurrentId { get; set; } // İlgili cari hesabın ID'si (Opsiyonel)

        // Siparişin oluşturulma tarihi gibi sistem tarafından otomatik atanacak alanlar da eklenebilir
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Durum")]
        public DataStatus Status { get; set; } // Kategori durumu
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } // Kategori aktif mi?
        // Siparişle ilişkili ürünlerin listesi
        [Display(Name = "Sipariş Ürünleri")]
        public List<ProductOrderViewModel> ProductOrders { get; set; }

        // Siparişle ilişkili ödemelerin listesi
        [Display(Name = "Sipariş Ödemeleri")]
        public List<PaymentViewModel> Payments { get; set; }

        public OrderViewModel()
        {
            ProductOrders = new List<ProductOrderViewModel>();
            Payments = new List<PaymentViewModel>();
        }
    }
}
