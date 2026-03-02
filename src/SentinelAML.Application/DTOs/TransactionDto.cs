using SentinelAML.Domain.Enums;

namespace SentinelAML.Application.DTOs;

public record TransactionDto (
    long Id,
    decimal Amount,
    CurrencyType Currency,
    CountryType CounterpartyCountry,
    TransactionDirection Direction,
    CustomerDto? Customer,
    DateTimeOffset Timestamp
);