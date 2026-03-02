using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Services;

public class TransactionService(ITransactionRepository repository) {
    
    
    public async Task<List<Transaction>> GetTransactionsAsync() {
        return await repository.GetAllAsync();
    }
}