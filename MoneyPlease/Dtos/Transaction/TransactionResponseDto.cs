using MoneyPlease.Enums;

namespace MoneyPlease.Dtos.Transaction
{
    public class TransactionResponseDto
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

    }
}
