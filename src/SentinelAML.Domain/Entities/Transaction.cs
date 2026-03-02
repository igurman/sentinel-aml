using SentinelAML.Domain.Enums;

namespace SentinelAML.Domain.Entities;

public class Transaction {
    public long Id { get; private set; }
    public long CustomerId { get; private set; }
    public decimal Amount { get; private set; }
    public CurrencyType Currency { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }
    public CountryType CounterpartyCountry { get; private set; }
    public TransactionDirection Direction { get; private set; }

    public Customer? Customer { get; private set; }

    public Transaction(long id, long customerId, decimal amount, CurrencyType currency, 
        DateTimeOffset timestamp, CountryType counterpartyCountry, TransactionDirection direction) {
        Id = id;
        CustomerId = customerId;
        Amount = amount;
        Currency = currency;
        Timestamp = timestamp;
        CounterpartyCountry = counterpartyCountry;
        Direction = direction;
    }
}