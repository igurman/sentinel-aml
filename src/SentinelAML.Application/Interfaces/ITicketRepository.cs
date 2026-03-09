using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Interfaces;

public interface ITicketRepository : IRepository<Ticket> {
    IQueryable<Ticket> GetTicketsQuery(TicketViewFilter filter);
}