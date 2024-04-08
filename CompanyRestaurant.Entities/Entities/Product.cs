using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public int UnitInStock { get; set; } // Eğer stok miktarı ondalıklı bir değer tutacaksa, int yerine decimal kullanabilirsiniz.
        //Mapping
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } // bir
        public virtual List<ProductOrder> ProductOrders { get; set; } //çok
    }
}