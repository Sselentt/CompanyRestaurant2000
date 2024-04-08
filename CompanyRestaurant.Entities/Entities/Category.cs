using CompanyRestaurant.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.Entities.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //Mapping
        public virtual List<Product> Products { get; set; }
    }
}
