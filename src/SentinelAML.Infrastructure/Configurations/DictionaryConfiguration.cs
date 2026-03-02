using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Configurations;

public class DictionaryConfiguration : IEntityTypeConfiguration<DictionaryEntity>
{
    public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
    {
        builder.HasIndex(x => new { x.Name, x.Dict }).IsUnique();
        
        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWID()");
        
        builder.Property(x => x.Type)
            .HasConversion<int>();

        builder.Property(x => x.CreatedAt)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("getdate()");
        
        
        
    }
}