using bookstore.Models;
using bookstore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignupUser([FromBody] SignupModel signupModel)
        {
            var result = await accountRepository.SignupAsync(signupModel);
            
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        
        }
        [HttpPost("login")]
        public async Task<IActionResult> SigninUser([FromBody] SigninModel signinModel)
        {
            var result = await accountRepository.LoginAsync(signinModel);

            if (string.IsNullOrEmpty(result))
            {
            return Unauthorized();
            }
                return Ok(result);

        }


    }
}
