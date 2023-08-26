using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingDbContext _context;

        public CategoryRepository(ShoppingDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryModel>> GetAllCategory()
        {
            var record = await _context.Categories.Select(x=>new CategoryModel()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToListAsync();
            return record;
        }
    }
}
