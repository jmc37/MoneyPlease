using Microsoft.AspNetCore.Mvc;

namespace MoneyPlease.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : Controller
    {

        public IActionResult GetTransaction(string transactionId)
        {
            return View();
        }

        public IActionResult CreateTransaction()
        {
            return View();
        }
        public IActionResult UpdateTransaction(string transactionId)
        {
            return View();
        }
        public IActionResult DeleteTransaction(string transactionId)
        {
            return View();
        }
    }
}
