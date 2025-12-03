using MoneyPlease.Dtos;
using MoneyPlease.Services;

public interface IAccountService
{
    Task<ServiceResult> CreateAccountAsync(CreateAccountDto dto);
    Task<ServiceResult> LoginAsync(LoginDto loginDto);
}