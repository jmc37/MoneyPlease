using MoneyPlease.Models;
using MoneyPlease.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace MoneyPlease.Services
{
    public class TokenService: ITokenService
    {

        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) {
            _config = config;
         }

        public string GenerateToken(User user)
        {
            var jwtSection = _config.GetSection("JWT");
            var jwtKey = jwtSection["Key"] ?? throw new InvalidOperationException("JWT signing key is missing!"); ;
            var jwtIssuer = jwtSection["Issuer"];
            var jwtAudience = jwtSection["Audience"];
            var expireMinutes = int.Parse(jwtSection["ExpireMinutes"] ?? "60");
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtKey) ) ;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
           var token = new JwtSecurityToken(
           issuer: jwtIssuer,
           audience: jwtAudience,
           claims: claims,
           expires: DateTime.UtcNow.AddMinutes(expireMinutes),
           signingCredentials: credentials
       );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
