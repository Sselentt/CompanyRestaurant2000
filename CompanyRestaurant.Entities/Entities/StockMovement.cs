using CompanyRestaurant.Entities.Base;
using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.Entities.Entities
{
    public class StockMovement : BaseEntity
    {
        public StockMovementType MovementType { get; set; }
        public decimal Quantity { get; set; }
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }
        public string Description { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
