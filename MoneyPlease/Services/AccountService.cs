using Microsoft.EntityFrameworkCore;
using MoneyPlease.Data;
using MoneyPlease.Dtos;
using MoneyPlease.Models;

namespace MoneyPlease.Services
{

    public interface IAccountService
    {
        Task<ServiceResult> CreateAccountAsync(CreateAccountDto dto);
        Task<ServiceResult> LoginAsync(LoginDto loginDto);
    }
    public class AccountService : IAccountService
    {
        private readonly MoneyPleaseContext _context;
        public AccountService(MoneyPleaseContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult> CreateAccountAsync(CreateAccountDto dto)
        {
            if(await _context.Users.AnyAsync(u =>u.Email == dto.Email))
                return ServiceResult.Failure("Email already in use.");

            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hash,
                PhoneNumber = dto.PhoneNumber
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            AccountResponseDto response = new AccountResponseDto { Id = user.Id, Name = user.Name, Email = user.Email };
            // Implementation for creating an account goes here
            return ServiceResult<AccountResponseDto>.SuccessResult(response, "Account created successfully.");
        }

        public async Task<ServiceResult> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return ServiceResult.Failure("Invalid Email");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isValid)
                return ServiceResult.Failure("Incorrect password");

            var response = new LoginResponseDto {Id = user.Id, Email = dto.Email, Name = user.Name };
            return ServiceResult<LoginResponseDto>.SuccessResult(response, "Login successful"); ;
        }
    }
}
