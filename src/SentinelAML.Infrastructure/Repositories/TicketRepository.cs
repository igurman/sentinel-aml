using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.DTOs;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Constants;
using SentinelAML.Domain.Entities;
using SentinelAML.Infrastructure.Data;

namespace SentinelAML.Infrastructure.Repositories;

public class TicketRepository(AppDbContext context) : ITicketRepository {
    public async Task<Ticket?> GetByIdAsync(long id) => await context.Tickets.FindAsync(id);

    public async Task<List<Ticket>> GetAllAsync() => await context.Tickets.ToListAsync();

    public async Task AddAsync(Ticket entity) => await context.Tickets.AddAsync(entity);

    public void Update(Ticket entity) => context.Tickets.Update(entity);

    public void Remove(Ticket entity) => context.Tickets.Remove(entity);

    public IQueryable<Ticket> GetTicketsQuery(TicketViewFilter filter) {
        var query = context.Tickets
            .AsNoTracking()
            .Include(a => a.Alert!.Customer)
            .AsQueryable();
        
        query = AddNameCondition(query, filter);
        query = AddPriorityCondition(query, filter);
        query = AddAssignedCondition(query, filter);
        query = AddStatusCondition(query, filter);

        return query;
    }
    
    private static IQueryable<Ticket> AddNameCondition(IQueryable<Ticket> query, TicketViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Name)) return query;
        
        return query.Where(a =>
            a.Id.ToString().Contains(filter.Name));
    }
    
    private static IQueryable<Ticket> AddPriorityCondition(IQueryable<Ticket> query, TicketViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Priority)) return query;

        var priority = filter.Priority switch {
            "high" => TicketPriorityType.High,
            "medium" => TicketPriorityType.Medium,
            "low" => TicketPriorityType.Low,
            _ => TicketPriorityType.Low
        };
        return query.Where(a => a.Priority == priority);
    }
    
    private static IQueryable<Ticket> AddAssignedCondition(IQueryable<Ticket> query, TicketViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Assigned)) return query;
        
        return query.Where(a =>
            a.AssignedTo.Equals(filter.Assigned));
    }
    
    private static IQueryable<Ticket> AddStatusCondition(IQueryable<Ticket> query, TicketViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Status)) return query;
        
        var status = filter.Status switch {
            "open" => TicketStatus.Open,
            "investigating" => TicketStatus.Investigating,
            "escalated" => TicketStatus.Escalated,
            "closed" => TicketStatus.Closed,
            _ => TicketStatus.Open
        };

        return query.Where(a => a.Status == status);
    }
    
}