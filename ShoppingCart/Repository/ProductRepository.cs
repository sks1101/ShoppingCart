using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingDbContext _context;

        public ProductRepository(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            var records = await _context.Products.Select(x => new ProductModel()
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                Stock = x.Stock
            })
            .ToListAsync();

            return records;
        }
    }
}
