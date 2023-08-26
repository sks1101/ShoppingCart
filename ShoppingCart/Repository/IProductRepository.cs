using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProduct();
    }
}
