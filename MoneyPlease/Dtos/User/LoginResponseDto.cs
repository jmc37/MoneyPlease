namespace MoneyPlease.Dtos.User
{
    public class LoginResponseDto
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}
