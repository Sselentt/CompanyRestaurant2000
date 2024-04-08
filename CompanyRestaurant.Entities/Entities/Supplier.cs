using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Supplier:BaseEntity
    {
        public string CompanyName { get; set; }
        public string City { get; set; }  //Mapping'lere city eklenecek.
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        

        //Relation Properties
        public virtual List<MaterialPrice> MaterialPrices { get; set; }
    }
}
