using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _orders;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _orders = ordersRepository;
        }
        [HttpGet("Order")]
        public async Task<List<OrderModel>> TotalOrders()
        {
            var records = await _orders.TotalItem();
            return records;
        }
        [HttpGet("Total Price")]
        public async Task<double> TotalP()
        {
            var total = await _orders.TotalPrice();
            return total;
        } 
    }
}
