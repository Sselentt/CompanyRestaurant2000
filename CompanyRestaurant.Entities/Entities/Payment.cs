using CompanyRestaurant.Entities.Base;
using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.Entities.Entities
{
    public class Payment:BaseEntity
    {
        // Ödemenin tutarı
        public decimal Amount { get; set; }

        // Ödeme tipi (TL, Euro, Dollar vs.)
        public PaymentType PaymentType { get; set; }

        // İlişkili siparişin ID'si
        public int OrderId { get; set; }

        // İlişkili sipariş
        public virtual Order Order { get; set; }

        // Ödeme açıklaması (isteğe bağlı)
        public string Description { get; set; }

        // Ödeme tarihi
        public DateTime PaymentDate { get; set; }
    }
}
