using EagleBank.Domain.Entities;
using EagleBank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EagleBank.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IDbContext _dbContext;
    
    public TransactionRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Transaction> AddTransactionAsync(Transaction transaction)
    {
        transaction = _dbContext.Transactions.Add(transaction).Entity;
        await _dbContext.SaveChangesAsync();
        return transaction;
    }
}