using MoneyPlease.Dtos;
using MoneyPlease.Models;

namespace MoneyPlease.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult> CreateAccountAsync (CreateAccountDto dto);

        bool DeleteAccountAsync (long id);
    }
}
