using EagleBank.Domain.Entities;
using EagleBank.Domain.Enums;

namespace EagleBank.Application.Dtos;

public class TransactionDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }

    public static TransactionDto FromEntity(Transaction transaction)
    {
        return new TransactionDto
        {
            Id = transaction.Id,
            Name = transaction.Name,
            Amount = transaction.Amount,
            Type = transaction.Type == TransactionType.Deposit ? "Deposit" : "Withdraw",
            DateTime = transaction.DateTime
        };
    }
}