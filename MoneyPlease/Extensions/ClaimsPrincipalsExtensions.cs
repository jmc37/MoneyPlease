using System.Security.Claims;

namespace MoneyPlease.Extensions
{
    public static class ClaimsPrincipalsExtensions
    {
        public static long GetUserId(this ClaimsPrincipal user)
        {
            var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id != null ? long.Parse(id): throw new Exception("User ID missing from token");
        }
    }
}
