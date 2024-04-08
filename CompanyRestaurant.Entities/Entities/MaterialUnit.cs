using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class MaterialUnit:BaseEntity
    {
        public string Unit { get; set; }
        public string Description { get; set; }


        //Relation Properties
        public int MaterialId { get; set; }
        public virtual List<Material> Materials { get; set; }
    }
}
