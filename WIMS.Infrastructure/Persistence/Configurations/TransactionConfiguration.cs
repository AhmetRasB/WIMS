using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WIMS.Domain.Transactions;

namespace WIMS.Infrastructure.Persistence.Configurations;

public sealed class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(id => id.Value, v => new TransactionId(v));
        builder.Property(x => x.Quantity).HasPrecision(18, 6);
        builder.Property(x => x.FeeTry).HasPrecision(18, 4);

        builder.HasIndex(x => new
        {
            x.UserId,
            x.OccuredAt
        });
    }
}