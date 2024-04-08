using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IProductRepository:IRepository<Product>
    {
        Task SellProduct(int productId, int quantity);
    }
}
