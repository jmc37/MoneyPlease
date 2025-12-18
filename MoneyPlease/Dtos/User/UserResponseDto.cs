namespace MoneyPlease.Dtos.User
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
