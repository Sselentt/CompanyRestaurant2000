using CompanyRestaurant.Entities.Base;
using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.Entities.Entities
{
    public class Order : BaseEntity
    {
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? TableId { get; set; }
        public virtual Table Table { get; set; }
        //public int? AccountingId { get; set; }
        public int? CurrentId { get; set; } // CurrentId artık nullable
        public virtual Current Current { get; set; }
        public virtual List<ProductOrder> ProductOrders { get; set; }
        public virtual List<Payment> Payments { get; set; } //yeni eklendi

        public Order()
        {
            Payments = new List<Payment>();
            ProductOrders = new List<ProductOrder>();
        }
    }
}
