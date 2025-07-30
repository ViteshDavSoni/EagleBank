using EagleBank.Domain.Entities;

namespace EagleBank.Domain.Repositories;

public interface IAccountRepository
{
    Task<Account> AddAccountAsync(Account account);
    
    Task<Account?> GetAccountAsync(Guid id);

    Task<IReadOnlyCollection<Account>> GetAccountsAsync(string userEmail);
}