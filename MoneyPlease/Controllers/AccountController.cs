using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos;
using MoneyPlease.Services;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly  IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            var result = await _accountService.CreateAccountAsync(dto);
            return Ok(result);
        }
    }
}
