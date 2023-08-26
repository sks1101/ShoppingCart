using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface ISearchRepository
    {
        Task<ProductModel> GetProductByName(string name);
    }
}
