using SentinelAML.Domain.Enums;

namespace SentinelAML.Application.DTOs;

public record TicketDto(
    long Id, 
    string AssignedTo, 
    TicketStatus Status, 
    string Decision, 
    DateTimeOffset CreatedAt,
    AlertDto? Alert
);
    
