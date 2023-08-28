using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductPrice { get; set; }
    }
}
