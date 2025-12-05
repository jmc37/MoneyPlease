using MoneyPlease.Dtos;

namespace MoneyPlease.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult> CreateAccountAsync (CreateAccountDto dto);

        Task<ServiceResult> GetAccountsAsync(long userId);
        Task<ServiceResult> GetAccountAsync(long id);

        Task<ServiceResult> DeleteAccountAsync (long id);
    }
}
