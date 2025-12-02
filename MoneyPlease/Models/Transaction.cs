namespace MoneyPlease.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public decimal Cost { get; set; }
        public Guid AccountId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }
        public Account Account { get; set; }
    }
}
