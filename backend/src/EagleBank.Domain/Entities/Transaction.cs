using EagleBank.Domain.Enums;

namespace EagleBank.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Account Account { get; set; }
    public string Name { get; set; }
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }

    public Transaction(Guid id, Guid accountId, string name, TransactionType type, decimal amount, DateTime dateTime)
    {
        Id = id;
        AccountId = accountId;
        Name = name;
        Type = type;
        Amount = amount;
        DateTime = dateTime;
    }
    
    public static Transaction CreateTransaction(Guid accountId, string name, TransactionType type, decimal amount)
    {
        return new Transaction(Guid.NewGuid(), accountId, name, type, amount, DateTime.UtcNow);
    }
}