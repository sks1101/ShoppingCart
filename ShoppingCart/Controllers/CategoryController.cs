using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _category = categoryRepository;
        }
        [HttpGet]
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            var record = await _category.GetAllCategory();
            return record;
        }
    }
}
