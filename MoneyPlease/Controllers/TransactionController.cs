using Microsoft.AspNetCore.Mvc;
using MoneyPlease.Dtos.Transaction;
using MoneyPlease.Services;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetTransaction(string transactionId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTransaction(CreateTransactionDto dto)
        {

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTransaction(string transactionId)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTransaction(string transactionId)
        {
            return Ok();
        }
    }
}
