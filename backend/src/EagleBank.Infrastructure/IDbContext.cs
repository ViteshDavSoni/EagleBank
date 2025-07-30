using EagleBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EagleBank.Infrastructure;

public interface IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}