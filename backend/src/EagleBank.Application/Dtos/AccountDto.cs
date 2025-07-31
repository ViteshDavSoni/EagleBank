using EagleBank.Domain.Entities;
using EagleBank.Domain.Enums;

namespace EagleBank.Application.Dtos;

public class AccountDto
{
    public Guid Id { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }

    public static AccountDto FromEntity(Account account)
    {
        return new AccountDto
        {
            Id = account.Id,
            AccountName = account.AccountName,
            UserId = account.UserId,
            Balance = account.Balance,
        };
    }
    
    private static decimal GetBalance(IReadOnlyCollection<Transaction> transactions)
    {
        var deposits = transactions.Where(t => t.Type == TransactionType.Deposit).Sum(t => t.Amount);
        var withdrawals = transactions.Where(t => t.Type == TransactionType.Withdraw).Sum(t => -t.Amount);
        return deposits + withdrawals;
    }
}