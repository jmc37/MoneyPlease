using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class AccountController : ControllerBase 
    {
        IAccountService _accountService;
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

        [HttpGet("")]
    }
}
