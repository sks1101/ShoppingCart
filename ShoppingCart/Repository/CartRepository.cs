 using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ShoppingDbContext _context;

        public CartRepository(ShoppingDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<GetCartModel>> GetCart()
        {
            var record = await _context.Carts.Select(x=>new GetCartModel()
            {
                Id = x.Id,
                ProductName = x.Products.ProductName,
                ProductDescription = x.Products.ProductDescription,
                ProductPrice = x.Products.ProductPrice,
                Quantity = x.Quantity
            }).ToListAsync();
            return record;
        }

        public async Task DeleteFromCart(int id)
        {
            var recordItem = _context.Carts.Where(x => x.Id == id).FirstOrDefault();
            
            _context.Carts.Remove(recordItem);
            await _context.SaveChangesAsync();
        }

        public async Task AddToCart(UpdateCartModel cart, string productname)
        {
           
            var prod2 = new Cart()
            {
                Id = cart.Id,
                Quantity = cart.Quantity
                
            };
            _context.Carts.Add(prod2);
            await _context.SaveChangesAsync();

            var record = _context.Products.Where(x=>x.ProductName == productname).FirstOrDefault();
            record.cartId = cart.Id;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCart(string productname, int quantity)
        {
            var record = _context.Carts.Where(x=>x.Products.ProductName == productname && x.Quantity>0 ).FirstOrDefault();
   
            record.Quantity = quantity;
            await _context.SaveChangesAsync();
        }
    }
}
