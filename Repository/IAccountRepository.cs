using Microsoft.AspNetCore.Identity;
using bookstore.Models;
namespace bookstore.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignupAsync(SignupModel signupModel);
        public Task<string> LoginAsync(SigninModel signinModel);
    }
}
