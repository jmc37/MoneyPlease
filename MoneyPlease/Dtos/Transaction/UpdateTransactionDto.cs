using System.ComponentModel.DataAnnotations;
using MoneyPlease.Enums;

namespace MoneyPlease.Dtos.Transaction
{
    public class UpdateTransactionDto
    {
        [Required]
        public long Id { get; set; }

        [Required, MaxLength(100)]
        public required string Title { get; set; }

        [Required, Range(0.01, 1000000)]
        public decimal Amount { get; set; }
        [Required, Range(0, 1)]
        public TransactionType Type { get; set; }
        public required long AccountId { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
