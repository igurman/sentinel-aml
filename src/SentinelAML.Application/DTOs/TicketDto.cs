using SentinelAML.Domain.Constants;

namespace SentinelAML.Application.DTOs;

public record TicketDto(
    long Id, 
    string AssignedTo, 
    TicketStatus Status, 
    TicketPriorityType Priority, 
    string Decision, 
    DateTimeOffset CreatedAt,
    AlertDto? Alert
);
    
