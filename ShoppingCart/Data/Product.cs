using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        
        public int ProductPrice { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public int cartId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Categories { get; set; }
        [ForeignKey("cartId")]
        public virtual Cart Carts { get; set; }

    }
}
