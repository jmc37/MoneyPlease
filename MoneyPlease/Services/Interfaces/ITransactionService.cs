using MoneyPlease.Dtos.Transaction;

namespace MoneyPlease.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task<ServiceResult> GetTransaction(string transactionId);
        public Task<ServiceResult> CreateTrasaction(long UserId, CreateTransactionDto dto);
        public Task<ServiceResult> UpdateTransaction(CreateTransactionDto transaction);
        public Task<ServiceResult> DeleteTrasaction(string transactionId);

    }
}
