using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Repository
{
    public class OrdersRepository:IOrdersRepository
    {
        private readonly ShoppingDbContext _context;
       
        public OrdersRepository(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderModel>> TotalItem()
        {
            var records = await _context.Carts.Select(x => new OrderModel()
            {
                ProductName = x.Products.ProductName,
                ProductPrice = x.Products.ProductPrice,
                Quantity = x.Quantity
            }).ToListAsync();
            return records;
        }

        public async Task<double> TotalPrice()
        {
            var total = _context.Carts.Select(x => x.Products.ProductPrice * x.Quantity).Sum();
            return total;
        }

        public async Task ExecuteOrder()
        {
            var records = await _context.Carts.Select(x => new Order()
            {
                ProductName = x.Products.ProductName,
                ProductPrice = x.Products.ProductPrice,
                Quantity = x.Quantity
            }).ToListAsync();
            foreach (var record in records)
            {
                _context.Orders.Add(record);
                _context.SaveChanges();
            }
        }
    }
}
