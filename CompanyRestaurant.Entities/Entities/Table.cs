using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Table:BaseEntity
    {
        public int TableNo { get; set; }
        public bool RezStatus { get; set; }
        public int PersonCapacity { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<Rezervation> Rezervations { get; set; }
    }
}
