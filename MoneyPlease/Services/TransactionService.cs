using Microsoft.EntityFrameworkCore;
using MoneyPlease.Data;
using MoneyPlease.Dtos.Transaction;
using MoneyPlease.Models;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Services
{
    public class TransactionService: ITransactionService
    {

        MoneyPleaseContext _context;
        public TransactionService(MoneyPleaseContext context) {
            _context = context;
        }

        public async Task<ServiceResult> CreateTrasaction(long userId, CreateTransactionDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(account => account.Id == dto.AccountId && account.UserId == userId);
            if (account == null)
                return ServiceResult.Failure("Account doesn't exist");
            var entity = new Transaction
            {
                Title = dto.Title,
                Amount = dto.Amount,
                AccountId = dto.AccountId,
                TransactionType = dto.TransactionType,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();
            TransactionResponseDto response = new TransactionResponseDto { Id = dto.AccountId, Title = dto.Title, Amount = dto.Amount };
            return ServiceResult<TransactionResponseDto>.SuccessResult(response);
        }

        public async Task<ServiceResult> DeleteTrasaction(long userId, long transactionId)
        {
            var rows = await _context.Transactions.Where(t => t.Id == transactionId && t.Account.UserId == userId).ExecuteDeleteAsync();
            if(rows == 0) 
                return ServiceResult.Failure("Transaction doesn't exist");
            return ServiceResult.SuccessResult("Transaction successfully deleted");
        }

        public async Task<ServiceResult> GetTransaction(long userId, long transactionId)
        {
            var transaction = await _context.Transactions.Where(t => t.Id == transactionId && t.Account.UserId == userId)
                .Select(t => new TransactionResponseDto { Id = t.Id, Title = t.Title, Amount = t.Amount, TransactionType = t.TransactionType })
                .FirstOrDefaultAsync();
            if (transaction == null)
                return ServiceResult.Failure("Transaction doesn't exist");
            return ServiceResult<TransactionResponseDto>.SuccessResult(transaction);
        }

        public async Task<ServiceResult> UpdateTransaction(long userId, UpdateTransactionDto transaction)
        {
            var rows = await _context.Transactions.Where(t => t.Id == transaction.Id && t.Account.UserId == userId)
                .ExecuteUpdateAsync(t => t
                    .SetProperty(t => t.Title, transaction.Title)
                    .SetProperty(t => t.Amount, transaction.Amount)
                    .SetProperty(t => t.LastUpdatedAt, DateTime.UtcNow)
                );
            if (rows == 0)
                return ServiceResult.Failure("Transaction doesn't exist");
            return ServiceResult.SuccessResult("Transaction successfully updated");
        }

    }
}
