using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class RecipeMaterial:BaseEntity
    {
        public int RecipeID { get; set; }
        public int MaterialID { get; set; }

        //Relation properties
        public virtual Recipe Recipe { get; set; }
        public virtual Material Material { get; set; }

        public decimal Quantity { get; set; }
    }
}
