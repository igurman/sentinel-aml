using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Configurations;

public class AlertConfiguration : IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts");

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR AlertSeq");

        builder.Property(x => x.RiskScore)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<string>();

        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.CreatedAt);
        
        builder.HasOne(x => x.Transaction)
            .WithMany()
            .HasForeignKey(x => x.TransactionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
    }
}
