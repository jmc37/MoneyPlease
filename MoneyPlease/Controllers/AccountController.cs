using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase 
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("account/CreateAccount")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            var result = await _accountService.CreateAccountAsync(dto); 
            return Ok(result); 
        }

        [HttpGet("user/{userId}/GetAccounts")]
        public async Task<IActionResult> GetAccounts(long id)
        {
            var result = await _accountService.GetAccountsAsync(id);
            return Ok(result);
        }

        [HttpGet("account/{id}/GetAccount")]
        public async Task<IActionResult> GetAccount(long id)
        {
            var result = await _accountService.GetAccountAsync(id);
            return Ok(result);
        }

        [HttpDelete("account/{id}/DeleteAccount")]
        public async Task<IActionResult> DeleteAccount(long id)
        {
            var result = await _accountService.DeleteAccountAsync(id);
            return Ok(result);
        }
    }
}
