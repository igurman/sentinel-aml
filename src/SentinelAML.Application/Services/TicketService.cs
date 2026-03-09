using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.DTOs;
using SentinelAML.Application.Interfaces;
using SentinelAML.Application.Mappers;

namespace SentinelAML.Application.Services;

public class TicketService(ITicketRepository repository, TicketMapper ticketMapper) {

    public async Task<(List<TicketDto> Items, PageInit pageInit, Dictionary<string, int> statusMap)> 
        GetTicketsFilterPaginated(TicketViewFilter filter, int page, int pageSize)
    {
        var query = repository.GetTicketsQuery(filter);
        
        var totalItems = await query.CountAsync();
        
        var statusMap = await query
            .GroupBy(a => a.Status)
            .Select(g => new 
            { 
                Status = g.Key.ToString(), 
                Count = g.Count() 
            })
            .ToDictionaryAsync(x => x.Status, x => x.Count);

        var entities = await query
            .OrderBy(a => a.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var dtoList = entities
            .Select(ticketMapper.Map)
            .Where(a => a != null)
            .ToList();

        var pageInit = new PageInit(
            page,
            pageSize,
            (int)Math.Ceiling(totalItems / (double)pageSize),
            totalItems
        );

        return (dtoList, pageInit, statusMap)!;
    }
}