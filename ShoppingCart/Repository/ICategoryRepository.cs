using ShoppingCart.Models;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryModel>> GetAllCategory();
    }
}
