using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos;
using MoneyPlease.Services.Interfaces;
using MoneyPlease.Extensions;
namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    [Authorize]
    public class AccountController : ControllerBase 
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/CreateAccount")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            long userId = User.GetUserId();
            var result = await _accountService.CreateAccountAsync(userId, dto); 
            return Ok(result); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            long userId = User.GetUserId();
            var result = await _accountService.GetAccountsAsync(userId);
            return Ok(result);
        }

        [HttpGet("{accountId:long}")]
        public async Task<IActionResult> GetAccount(long accountId)
        {
            long userId = User.GetUserId();
            var result = await _accountService.GetAccountAsync(userId, accountId);
            return Ok(result);
        }

        [HttpDelete("{accountId:long}")]
        public async Task<IActionResult> DeleteAccount(long accountId)
        {
            long userId = User.GetUserId();
            var result = await _accountService.DeleteAccountAsync(userId, accountId);
            return Ok(result);
        }
    }
}
