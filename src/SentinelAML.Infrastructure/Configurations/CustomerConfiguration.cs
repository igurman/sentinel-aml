using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder) {
        builder.ToTable("Customers");

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR CustomerSeq");

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(x => x.Country)
            .HasConversion<string>();

        builder.Property(x => x.IsPep)
            .IsRequired();

        builder.Property(x => x.RiskLevel)
            .HasConversion<string>();

        builder.HasIndex(x => x.RiskLevel);
    }
}
