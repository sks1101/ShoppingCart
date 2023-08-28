using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _orders;
        private readonly IEmailService _emailService;

        public OrdersController(IOrdersRepository ordersRepository, IEmailService emailService)
        {
            _orders = ordersRepository;
            _emailService = emailService;
        }
        [HttpGet("Order")]
        public async Task<List<OrderModel>> TotalOrders()
        {
            MailRequest mailrequest = new MailRequest();
            mailrequest.ToEmail = "sameerksahu1120@gmail.com";
            mailrequest.Subject = "ORDERED PLACED SUCCESSFULLY";
            mailrequest.Body = "Thank You for Shopping With ShopKart.";
            await _emailService.SendEmailAsync(mailrequest);
            var records = await _orders.TotalItem();
            return records;
        }
        [HttpGet("Total Price")]
        public async Task<double> TotalP()
        {
            var total = await _orders.TotalPrice();
            return total;
        }
        [HttpPost("ALL Orders")]
        public async Task<IActionResult> AllOrders()
        {
            await _orders.ExecuteOrder();
            return Ok();
        }

    }
}
