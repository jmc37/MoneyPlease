namespace MoneyPlease.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
        public List<Transaction> Transactions { get; set; }

    }
}
