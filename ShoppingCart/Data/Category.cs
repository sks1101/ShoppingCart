using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
       
        public virtual ICollection<Product> Products { get; set; }

    }
}
