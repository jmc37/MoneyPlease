using MoneyPlease.Dtos.Account;

namespace MoneyPlease.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult> CreateAccountAsync (long userId, CreateAccountDto dto);

        Task<ServiceResult> GetAccountsAsync(long userId);
        Task<ServiceResult> GetAccountAsync(long userID, long accountId);

        Task<ServiceResult> DeleteAccountAsync (long userId, long accountId);
    }
}
