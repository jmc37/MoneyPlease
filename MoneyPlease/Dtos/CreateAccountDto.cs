namespace MoneyPlease.Dtos
{
    public class CreateAccountDto
    {
        public required long UserId { get; set; }
        public required string AccountName { get; set; }
    }
}
