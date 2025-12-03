namespace MoneyPlease.Models
{
    public class User
    {
        public long Id { get; set; }
        public required String Name { get; set; }
        public required string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public required String Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
