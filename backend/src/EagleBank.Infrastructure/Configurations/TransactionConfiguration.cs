using EagleBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EagleBank.Infrastructure.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(nameof(Transaction));
        builder.HasKey(x => x.Id);
        builder.HasOne(e => e.Account)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.AccountId);
        builder.Navigation(e => e.Account).AutoInclude();
    }
}