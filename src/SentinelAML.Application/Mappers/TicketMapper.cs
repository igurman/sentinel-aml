using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Mappers;

public class TicketMapper(/*IDictionaryProvider dictionary, */AlertMapper alertMapper) {

    public TicketDto? Map(Ticket? ticket) {
        if (ticket == null)
            return null;
        
        return new TicketDto(
            Id: ticket.Id,
            AssignedTo: ticket.AssignedTo, 
            Status: ticket.Status,
            Priority: ticket.Priority,
            Decision: ticket.Decision,
            Alert: alertMapper.Map(ticket.Alert),   
            CreatedAt: ticket.CreatedAt
        );
    }
}