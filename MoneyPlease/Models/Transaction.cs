namespace MoneyPlease.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public required string Title { get; set; }

        public decimal Cost { get; set; }
        public long AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
        public required Account Account { get; set; }
    }
}
