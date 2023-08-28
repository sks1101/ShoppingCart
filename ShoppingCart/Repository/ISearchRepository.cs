using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface ISearchRepository
    {
        Task<List<ProductModel>> GetProductByName(string name);
    }
}
