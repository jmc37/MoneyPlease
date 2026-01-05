namespace MoneyPlease.Dtos.Account
{
    public class AccountResponseDto
    {
        public long AccountId { get; set; }
        public required string Name { get; set; }

        public required decimal Balance { get; set; }
    }
}
