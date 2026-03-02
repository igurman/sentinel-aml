using SentinelAML.Domain.Enums;

namespace SentinelAML.Application.DTOs;

public record AlertDto(
    long Id, 
    int RiskScore, 
    List<string> Rules, 
    AlertStatus Status, 
    CustomerDto? Customer, 
    TransactionDto? Transaction,
    DateTimeOffset CreatedAt
);