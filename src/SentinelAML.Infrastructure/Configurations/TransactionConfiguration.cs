using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder) {
        builder.ToTable("Transactions");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR TransactionSeq");
        
        builder.Property(x => x.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Currency)
            .HasConversion<string>();

        builder.Property(x => x.CounterpartyCountry)
            .HasConversion<string>();

        builder.Property(x => x.Direction)
            .HasConversion<string>();

        builder.HasIndex(x => x.Timestamp);
        builder.HasIndex(x => x.CustomerId);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
