namespace MoneyPlease.Dtos
{
    public class CreateUserDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string  Password { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
