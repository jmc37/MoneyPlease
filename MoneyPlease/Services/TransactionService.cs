using Microsoft.EntityFrameworkCore;
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

        public async Task<ServiceResult> CreateTrasaction(long UserId, CreateTransactionDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == dto.AccountId);
            if (account == null)
                return ServiceResult.Failure("Account doesn't exist");
            await _context.AddAsync(dto);
            await _context.SaveChangesAsync();
            TransactionResponseDto response = new TransactionResponseDto { Id = dto.AccountId, Title = dto.Title };
            return ServiceResult<TransactionResponseDto>.SuccessResult(response);
        }

        public Task<ServiceResult> DeleteTrasaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> GetTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateTransaction(CreateTransactionDto transaction)
        {
            throw new NotImplementedException();
        }
        //public Task GetTransaction(string transactionId) { }

    }
}
