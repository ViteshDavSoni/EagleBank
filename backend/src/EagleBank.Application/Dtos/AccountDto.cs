using EagleBank.Domain.Entities;

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
}