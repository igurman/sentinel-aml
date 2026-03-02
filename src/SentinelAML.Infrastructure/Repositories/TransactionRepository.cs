using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Entities;
using SentinelAML.Infrastructure.Data;

namespace SentinelAML.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository {
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context) {
        _context = context;
    }

    public async Task AddAsync(Transaction entity) 
        => await _context.Transactions.AddAsync(entity);

    public async Task<Transaction?> GetByIdAsync(long id) 
        => await _context.Transactions.FindAsync(id);

    public async Task<List<Transaction>> GetAllAsync() 
        => await _context.Transactions.ToListAsync();

    public void Update(Transaction entity) 
        => _context.Transactions.Update(entity);

    public void Remove(Transaction entity) 
        => _context.Transactions.Remove(entity);

    public async Task<List<Transaction>> GetCustomerTransactionsLastMinute(long customerId) {
        var from = DateTimeOffset.UtcNow.AddMinutes(-1);

        return await _context.Transactions
            .Where(x => x.CustomerId == customerId && x.Timestamp >= from)
            .ToListAsync();
    }
}
