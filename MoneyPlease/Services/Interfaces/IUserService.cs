using MoneyPlease.Dtos;
using MoneyPlease.Services;

public interface IUserService
{
    Task<ServiceResult> CreateUserAsync(CreateUserDto dto);
    Task<ServiceResult> LoginAsync(LoginDto loginDto);
}