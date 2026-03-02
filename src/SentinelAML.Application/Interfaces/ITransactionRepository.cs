using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Interfaces;

public interface ITransactionRepository : IRepository<Transaction> {
    Task<List<Transaction>> GetCustomerTransactionsLastMinute(long customerId);
}
