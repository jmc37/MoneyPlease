using MoneyPlease.Data;
using MoneyPlease.Dtos.Transaction;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Services
{
    public class TransactionService: ITransactionService
    {

        MoneyPleaseContext _context;
        public TransactionService(MoneyPleaseContext context) {
            _context = context;
        }

        public Task CreateTrasaction(CreateTransactionDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrasaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task GetTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTransaction(CreateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }
        //public Task GetTransaction(string transactionId) { }

    }
}
