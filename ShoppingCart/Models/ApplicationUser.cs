using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    [Keyless]
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
