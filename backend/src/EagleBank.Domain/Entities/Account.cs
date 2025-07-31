using EagleBank.Domain.Enums;

namespace EagleBank.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public string AccountName { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Balance { get; private set; }
    public User User { get; private set; }
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();
    
    private List<Transaction> _transactions = new();

    public Account(Guid id, string accountName, Guid userId, decimal balance)
    {
        Id = id;
        AccountName = accountName;
        UserId = userId;
        Balance = balance;
    }

    public static Account CreateAccount(string accountName, Guid userId)
    {
        return new Account(Guid.NewGuid(), accountName, userId, 0);
    }

    public Account AddTransaction(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case TransactionType.Deposit:
                Balance += transaction.Amount;
                break;
            case TransactionType.Withdraw:
                Balance -= transaction.Amount;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return this;
    }
}