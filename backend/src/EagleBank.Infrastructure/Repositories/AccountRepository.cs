using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EagleBank.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IDbContext _dbContext;
    
    public AccountRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Account> AddAccountAsync(Account account)
    {
        account = _dbContext.Accounts.Add(account).Entity;
        await _dbContext.SaveChangesAsync();
        return account;
    }

    public async Task<Account?> GetAccountAsync(Guid id)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
    }
    
    public async Task<IReadOnlyCollection<Account>> GetAccountsAsync(string userEmail)
    {
        return await _dbContext.Accounts.Where(a => a.User.Email == userEmail).ToListAsync();
    }

    public async Task<Account> UpdateAccountAsync(Account account)
    {
        account = _dbContext.Accounts.Update(account).Entity;
        await _dbContext.SaveChangesAsync();
        return account;
    }
}