using MoneyPlease.Models;

namespace MoneyPlease.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
