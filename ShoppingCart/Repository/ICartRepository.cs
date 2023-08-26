using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface ICartRepository
    {
        Task<List<GetCartModel>> GetCart();
        Task DeleteFromCart(int id);
        Task AddToCart(UpdateCartModel cart, string productname);
        Task UpdateCart(string productname, int quantity);
    }
}
