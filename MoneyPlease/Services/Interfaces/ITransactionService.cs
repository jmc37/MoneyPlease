using MoneyPlease.Dtos.Transaction;

namespace MoneyPlease.Services.Interfaces
{
    public interface ITransactionService
    {
        public Task<ServiceResult> GetTransaction(long userId, long transactionId);
        public Task<ServiceResult> CreateTrasaction(long UserId, CreateTransactionDto dto);
        public Task<ServiceResult> UpdateTransaction(long userId, UpdateTransactionDto transaction);
        public Task<ServiceResult> DeleteTrasaction(long userId, long transactionId);

    }
}
