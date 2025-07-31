using EagleBank.Domain.Enums;
using EagleBank.Domain.Exceptions;

namespace EagleBank.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public string AccountName { get; private set; }
    public Guid UserId { get; private set; }
    public decimal Balance { get; private set; }
    public User User { get; private set; }
    public IReadOnlyCollection<Transaction> Transactions;
    
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

        if (Balance < 0)
        {
            throw new UnprocessableEntityException();  
        }
        
        return this;
    }
}