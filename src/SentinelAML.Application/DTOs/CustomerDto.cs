using SentinelAML.Domain.Enums;

namespace SentinelAML.Application.DTOs;

public record CustomerDto(
    long Id,
    string Name,
    CountryType Country,
    bool IsPep,
    RiskLevel RiskLevel,
    DateOnly CreatedAt
);