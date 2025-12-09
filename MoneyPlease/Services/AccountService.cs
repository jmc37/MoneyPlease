using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoneyPlease.Data;
using MoneyPlease.Dtos;
using MoneyPlease.Models;
using MoneyPlease.Services.Interfaces;

namespace MoneyPlease.Services
{
    public class AccountService: IAccountService
    {
        private readonly MoneyPleaseContext _context;
        public AccountService(MoneyPleaseContext context) {
            _context = context;
        }
        public async Task<ServiceResult> CreateAccountAsync(long userId, CreateAccountDto dto)
        {
            var account = new Account() { Name = dto.AccountName, UserId = userId };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            AccountResponseDto response = new AccountResponseDto() { Name = dto.AccountName, AccountId = account.Id };
            return ServiceResult<AccountResponseDto>.SuccessResult(response);
        }

        public async Task<ServiceResult> GetAccountsAsync(long userId)
        {
            var accounts = await _context.Accounts
                .Where(a => a.UserId == userId)
                .Select(a => new AccountResponseDto { AccountId = a.Id, Name = a.Name })
                .ToListAsync();
            return ServiceResult<List<AccountResponseDto>>.SuccessResult(accounts);
        }
        public async Task<ServiceResult> GetAccountAsync(long userId, long accountId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId && a.UserId == userId);
            if(account == null) 
                return ServiceResult.Failure("Account doesn't exist");
            AccountResponseDto response = new AccountResponseDto() { Name = account.Name, AccountId = account.Id };
            return ServiceResult<AccountResponseDto>.SuccessResult(response);
        }

        public async Task<ServiceResult> DeleteAccountAsync(long userId, long accountId)
        {
            var rows = await _context.Accounts.Where(a => a.Id == accountId && a.UserId == userId).ExecuteDeleteAsync();
            if (rows == 0)
                return ServiceResult.Failure("Account doesn't exist");
            return ServiceResult.SuccessResult("Account succesfully deleted");
        }
        
    }
}
