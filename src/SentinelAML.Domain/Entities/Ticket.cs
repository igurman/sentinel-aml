using SentinelAML.Domain.Constants;

namespace SentinelAML.Domain.Entities;

public class Ticket {
    public long Id { get; private set; }
    public long AlertId { get; private set; }
    public string AssignedTo { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriorityType Priority { get; private set; }
    public string Decision { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    
    public Alert? Alert { get; private set; }

    public Ticket(long id, long alertId, string assignedTo, TicketStatus status, TicketPriorityType priority, string decision, 
        DateTimeOffset createdAt) {
        Id = id;
        AlertId = alertId;
        AssignedTo = assignedTo;
        Status = status;
        Priority = priority;
        Decision = decision;
        CreatedAt = createdAt;
    }

    public void AddComment(string comment) {
        
    }
    
}