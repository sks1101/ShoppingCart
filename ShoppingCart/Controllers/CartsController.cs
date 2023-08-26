using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using System.Runtime.CompilerServices;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet]
        public async Task<List<GetCartModel>> GetItems()
        {
            var records = await _cartRepository.GetCart();
            return records;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            await _cartRepository.DeleteFromCart(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(UpdateCartModel cart, string productname)
        {
            await _cartRepository.AddToCart(cart,productname);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCart(string productName, int quantity)
        {
            await _cartRepository.UpdateCart(productName, quantity);
            return Ok();
        }
    }
}
