using MoneyPlease.Data;

namespace MoneyPlease.Services
{
    public class TransactionService
    {

        MoneyPleaseContext _context;
        public TransactionService(MoneyPleaseContext context) {
            _context = context;
        }
        //public Task GetTransaction(string transactionId) { }

    }
}
