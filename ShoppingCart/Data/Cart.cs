using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Data
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }


        public virtual Product Products { get; set; }
    }
}
