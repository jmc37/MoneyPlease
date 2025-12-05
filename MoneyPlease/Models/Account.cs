namespace MoneyPlease.Models
{
    public class Account
    {
        public long Id { get; set; }

        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public required long UserId { get; set; }
        public User? User { get; set; }
        public List<Transaction>? Transactions { get; set; } = new();

    }
}
