using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos.Transaction;
using MoneyPlease.Extensions;
using MoneyPlease.Services;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    [Authorize]
    public class TransactionController : Controller
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransaction(string transactionId)
        {
            long userId = User.GetUserId();
            var result = await _transactionService.GetTransaction(userId, long.Parse(transactionId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionDto dto)
        {
            long user = User.GetUserId();
            var result = await _transactionService.CreateTrasaction(user, dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(UpdateTransactionDto dto)
        {
            long userId = User.GetUserId();
            var result = await _transactionService.UpdateTransaction(userId, dto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTransaction(string transactionId)
        {
            long userId = User.GetUserId();
            var result = await _transactionService.DeleteTrasaction(userId, long.Parse(transactionId));
            return Ok(result);
        }
    }
}
