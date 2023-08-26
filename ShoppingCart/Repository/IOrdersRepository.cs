using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IOrdersRepository
    {
        Task<List<OrderModel>> TotalItem();
        Task<double> TotalPrice();
    }
}
