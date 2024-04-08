using CompanyRestaurant.Entities.Base;

namespace CompanyRestaurant.Entities.Entities
{
    public class Material : BaseEntity
    {
        public string MaterialName { get; set; }
        public decimal Price { get; set; }
        public decimal UnitInStock { get; set; }

        // Relation Properties
        public virtual List<RecipeMaterial> RecipeMaterial { get; set; }
        public int UnitStockID { get; set; }
        public virtual UnitStock UnitStock { get; set; }

        // Material'un birim tipi
        public int MateriUnitId { get; set; }
        public virtual MaterialUnit MaterialUnit { get; set; }

        // Material fiyatı
        public int MaterialPriceId { get; set; }
        public virtual MaterialPrice MaterialPrice { get; set; }

        // Material'e ait stok hareketleri
        public virtual List<StockMovement> StockMovements { get; set; } // Yeni eklenen ilişki

        public Material()
        {
            RecipeMaterial = new List<RecipeMaterial>();
            StockMovements = new List<StockMovement>(); // İnitialize edilmesi
        }
    }
}
