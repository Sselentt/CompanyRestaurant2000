using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public int Serves { get; set; } // Porsiyon bilgisi
        public TimeSpan PreparationTime { get; set; } // Hazırlık süresi
        public TimeSpan CookingTime { get; set; } // Pişirme süresi
        public string Instructions { get; set; } // Hazırlama talimatları
        public string ImageUrl { get; set; } // Reçetenin görseli

        // İlişkisel özellikler
        public int? ProductId { get; set; } // Ürün ile ilişkilendirme
        public virtual Product Product { get; set; }
        public virtual List<RecipeMaterial> RecipeMaterials { get; set; } // Malzeme listesi

        // Yeni eklenen maliyet hesaplama ile ilgili özellikler
        public decimal TotalCost { get; private set; } // Toplam maliyet

        // Constructor 
        public Recipe()
        {
            RecipeMaterials = new List<RecipeMaterial>();
        }

    }

}
