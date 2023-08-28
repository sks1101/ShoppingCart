using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [Route("Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository) 
        {
            _searchRepository = searchRepository;
        }
        [HttpGet]
        public async Task<List<ProductModel>>GetProductByName(string productName)
        {
            var record = await _searchRepository.GetProductByName(productName);
            return record;
        }
    }
}
