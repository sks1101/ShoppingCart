using Microsoft.AspNetCore.Identity;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUp signUpModel);
        Task<string> LoginAsync(SignIn signInModel);
    }
}
