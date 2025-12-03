namespace MoneyPlease.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }

        public decimal Cost { get; set; }
        public Guid AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
        public required Account Account { get; set; }
    }
}
