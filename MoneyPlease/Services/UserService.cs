using Microsoft.EntityFrameworkCore;
using MoneyPlease.Data;
using MoneyPlease.Dtos;
using MoneyPlease.Models;
using MoneyPlease.Services.Interfaces;
namespace MoneyPlease.Services
{
    public class UserService : IUserService
    {
        private readonly MoneyPleaseContext _context;
        private readonly ITokenService _tokenService;
        public UserService(MoneyPleaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult> CreateUserAsync(CreateUserDto dto)
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
            UserResponseDto response = new UserResponseDto { Id = user.Id, Name = user.Name, Email = user.Email };
            // Implementation for creating an account goes here
            return ServiceResult<UserResponseDto>.SuccessResult(response, "Account created successfully.");
        }

        public async Task<ServiceResult> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return ServiceResult.Failure("Invalid Email");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
            if (!isValid)
                return ServiceResult.Failure("Incorrect password");

            var token = _tokenService.GenerateToken(user);
            var response = new LoginResponseDto { Id = user.Id, Email = dto.Email, Name = user.Name, Token = token };
            return ServiceResult<LoginResponseDto>.SuccessResult(response, "Login successful"); ;
        }
    }
}
