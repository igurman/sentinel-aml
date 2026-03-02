using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Entities;
using SentinelAML.Infrastructure.Data;

namespace SentinelAML.Infrastructure.Repositories;

public class TicketRepository(AppDbContext context) : ITicketRepository {
    public async Task<Ticket?> GetByIdAsync(long id) => await context.Tickets.FindAsync(id);

    public async Task<List<Ticket>> GetAllAsync() => await context.Tickets.ToListAsync();

    public async Task AddAsync(Ticket entity) => await context.Tickets.AddAsync(entity);

    public void Update(Ticket entity) => context.Tickets.Update(entity);

    public void Remove(Ticket entity) => context.Tickets.Remove(entity);
    
}