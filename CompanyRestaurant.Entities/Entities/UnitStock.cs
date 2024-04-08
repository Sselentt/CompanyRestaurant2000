using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class UnitStock:BaseEntity
    {
        public int Stock { get; set; } // Otomatik olarak güncellenecek.
        public int CriticalStock { get; set; }
        public int MinimumStockLevel { get; set; }
        public bool IsCriticalLevelReached { get; set; }
        public UnitStock()
        {
            IsCriticalLevelReached = false;
        }

        //Realtion Properties
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }
       
    }
}
