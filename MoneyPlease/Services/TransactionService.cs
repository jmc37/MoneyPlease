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
            var signedAmount = dto.TransactionType == Enums.TransactionType.Expense ? -dto.Amount : dto.Amount;
            var entity = new Transaction
            {
                Title = dto.Title,
                Amount = signedAmount,
                AccountId = dto.AccountId,
                TransactionType = dto.TransactionType,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow
            };
            await using var tx = await _context.Database.BeginTransactionAsync();
            await _context.Accounts.Where(a => a.Id == account.Id).ExecuteUpdateAsync(a =>
            a.SetProperty(a => a.Balance,a => a.Balance + signedAmount));
            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();
            await tx.CommitAsync();
            TransactionResponseDto response = new TransactionResponseDto { Id = entity.Id, Title = dto.Title, Amount = signedAmount };
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
