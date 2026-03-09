using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Mappers;

public class TransactionMapper (/*IDictionaryProvider _dictionary,*/ CustomerMapper customerMapper) {

    public TransactionDto? Map(Transaction? transaction) {
        if (transaction == null)
            return null;

        return new TransactionDto(
            Id: transaction.Id,
            Amount: transaction.Amount,
            Currency: transaction.Currency,
            CounterpartyCountry: transaction.CounterpartyCountry,
            Direction: transaction.Direction,
            Customer: customerMapper.Map(transaction.Customer),
            Timestamp:  transaction.Timestamp
        );
    }
}