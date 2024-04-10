using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class MaterialPrice:BaseEntity
    {
        public decimal Price { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }

        //Realtion Properties
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }



        //ŞİMDİ YAPTIM
        public int MaterialId { get; set; }
        public virtual Material Materials { get; set; }

    }
}
