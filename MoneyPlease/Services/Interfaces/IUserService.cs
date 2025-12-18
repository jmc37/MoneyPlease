using MoneyPlease.Dtos.User;
using MoneyPlease.Models;
using MoneyPlease.Services;

public interface IUserService
{
    Task<ServiceResult> CreateUserAsync(CreateUserDto dto);
    Task<ServiceResult> LoginAsync(LoginDto loginDto);
}