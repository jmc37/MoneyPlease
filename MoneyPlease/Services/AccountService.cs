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
        public async Task<ServiceResult> CreateAccountAsync(CreateAccountDto dto)
        {
            Account account = new Account() { Name = dto.AccountName, UserId = dto.UserId };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            AccountResponseDto response = new AccountResponseDto() { Name = dto.AccountName, AccountId = account.Id };
            return ServiceResult<AccountResponseDto>.SuccessResult(response);
        }

        public bool DeleteAccountAsync(long id)
        {
            return true;
        }
        
    }
}
