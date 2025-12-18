using MoneyPlease.Dtos.Transaction;

namespace MoneyPlease.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task GetTransaction(string transactionId);
        public Task CreateTrasaction(CreateTransactionDto dto);

        public Task UpdateTransaction(CreateTransactionDto transaction);
        public Task DeleteTrasaction(string transactionId);

    }
}
