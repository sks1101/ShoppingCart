using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class SignUp
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
            
        public string ConfirmPassword { get; set; }
    }
}
