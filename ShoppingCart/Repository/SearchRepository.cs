using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;
using System.Text.RegularExpressions;

namespace ShoppingCart.Repository
{
    public class SearchRepository: ISearchRepository
    {
        private readonly ShoppingDbContext _Context;

        public SearchRepository(ShoppingDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<ProductModel>>GetProductByName(string name)
        {
            var record = await _Context.Products.Where(x => x.ProductName.Contains(name)).Select(x => new ProductModel()
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ProductPrice = x.ProductPrice,
                Stock = x.Stock
            }).ToListAsync();

            return record;
        }

    }
}
//ProductName.StartsWith(name) || x.ProductName.EndsWith(name)
