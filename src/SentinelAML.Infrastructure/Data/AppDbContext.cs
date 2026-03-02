using Microsoft.EntityFrameworkCore;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Infrastructure.Data;

public class AppDbContext : DbContext {
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Alert> Alerts => Set<Alert>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        modelBuilder.HasSequence<long>("CustomerSeq")
                    .StartsAt(5000)
                    .IncrementsBy(1);
        
        modelBuilder.HasSequence<long>("TransactionSeq")
                    .StartsAt(5000)
                    .IncrementsBy(1);
        
        modelBuilder.HasSequence<long>("AlertSeq")
            .StartsAt(5000)
            .IncrementsBy(1);
        
        modelBuilder.HasSequence<long>("TicketSeq")
            .StartsAt(5000)
            .IncrementsBy(1);
        
        base.OnModelCreating(modelBuilder);
    }
}