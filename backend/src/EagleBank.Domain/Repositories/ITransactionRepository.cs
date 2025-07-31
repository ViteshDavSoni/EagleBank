using EagleBank.Domain.Entities;

namespace EagleBank.Domain.Repositories;

public interface ITransactionRepository
{
    Task<Transaction> AddTransactionAsync(Transaction transaction);
}