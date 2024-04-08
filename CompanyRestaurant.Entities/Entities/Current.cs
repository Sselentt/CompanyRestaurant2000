using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Current:BaseEntity
    {
        // Temel Bilgiler
        public decimal Debit { get; set; } // Borç
        public decimal Credit { get; set; } // Alacak
        public decimal Balance => Debit - Credit; // Bakiye, hesaplama alanı

        // Cari Hesap Detayları
        public string AccountNumber { get; set; } // Hesap Numarası
        public string CompanyName { get; set; } // Şirket Adı (opsiyonel, bireysel müşteriler için kullanılmayabilir)
        public string ContactName { get; set; } // İletişim Adı
        public string ContactEmail { get; set; } // İletişim E-postası
        public string ContactPhone { get; set; } // İletişim Telefonu
        public string Address { get; set; } // Adres
        public string TaxNumber { get; set; } // Vergi Numarası (opsiyonel, bireysel müşteriler için kullanılmayabilir)
        public string TaxOffice { get; set; } // Vergi Dairesi (opsiyonel, bireysel müşteriler için kullanılmayabilir)

        // İlişkisel Özellikler
        public virtual List<Order> Orders { get; set; } // Cari hesaba ait siparişler

        // Müşteri ile ilişkilendirme (Opsiyonel olarak eklenebilir)
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        // Constructor
        public Current()
        {
            Orders = new List<Order>();
        }
    }
}
