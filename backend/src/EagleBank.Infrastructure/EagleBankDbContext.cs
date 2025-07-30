using EagleBank.Domain.Entities;
using EagleBank.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EagleBank.Infrastructure;

public class EagleBankDbContext: DbContext, IDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }

    public EagleBankDbContext(DbContextOptions<EagleBankDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}