using MoneyPlease.Enums;

namespace MoneyPlease.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public required string Title { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }
        public required long AccountId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastUpdatedAt { get; set; }
        public Account Account { get; set; } = null!;
    }
}
