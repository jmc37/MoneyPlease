namespace MoneyPlease.Dtos.Transaction
{
    public class CreateTransactionDto
    {
        public required string Title { get; set; }
        public decimal Amount { get; set; }
        public required long AccountId { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
