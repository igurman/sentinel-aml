using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket> {
    public void Configure(EntityTypeBuilder<Ticket> builder) {
        builder.ToTable("Tickets");

        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEXT VALUE FOR TicketSeq");
        
        builder.Property(x => x.AssignedTo)
            .HasConversion<string>();
        
        builder.Property(x => x.Status)
            .HasConversion<string>();
        
        builder.Property(x => x.Priority)
            .HasConversion<string>();
        
        builder.Property(x => x.Decision)
            .HasConversion<string>();

        // indexes
        builder.HasIndex(x => x.Status);
        builder.HasIndex(x => x.CreatedAt);


        builder.HasOne(x => x.Alert)
            .WithMany()
            .HasForeignKey(x => x.AlertId);
    }
}