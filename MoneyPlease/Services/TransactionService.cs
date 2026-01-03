using System.Transactions;
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

        public async Task<ServiceResult> DeleteTrasaction(string transactionId)
        {
            await _context.Transactions.Where(t => t.Id.ToString() == transactionId).ExecuteDeleteAsync();
            return ServiceResult.SuccessResult("Transaction successfully deleted");
        }

        public async Task<ServiceResult> GetTransaction(string transactionId)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id.ToString() == transactionId);
            if (transaction == null)
                return ServiceResult.Failure("Transaction doesn't exist");
            TransactionResponseDto response = new TransactionResponseDto { Id = transaction.AccountId, Title = transaction.Title };
            return ServiceResult<TransactionResponseDto>.SuccessResult(response);
        }

        public async Task<ServiceResult> UpdateTransaction(UpdateTransactionDto transaction)
        {
            await _context.Transactions.Where(t => t.Id == transaction.Id)
                .ExecuteUpdateAsync(t => t
                    .SetProperty(t => t.Title, transaction.Title)
                    .SetProperty(t => t.Amount, transaction.Amount)
                );
            await _context.SaveChangesAsync();
            return ServiceResult.SuccessResult("Transaction successfully updated");
        }
        //public Task GetTransaction(string transactionId) { }

    }
}
