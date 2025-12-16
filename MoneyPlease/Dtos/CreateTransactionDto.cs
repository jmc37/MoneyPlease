namespace MoneyPlease.Dtos
{
    public class CreateTransactionDto
    {
        public required string Title { get; set; }
        public decimal Cost { get; set; }
        public required long AccountId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
