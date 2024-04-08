using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly CompanyRestaurantContext _context;

        public ProductRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public async Task SellProduct(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found");
            }

            if (product.UnitInStock < quantity)
            {
                throw new InvalidOperationException("Insufficient stock for the product");
            }

            product.UnitInStock -= quantity; // Stoktan düşür
            await _context.SaveChangesAsync();
        }
    }

}
