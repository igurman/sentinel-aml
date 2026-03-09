using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.DTOs;
using SentinelAML.Application.Interfaces;
using SentinelAML.Application.Mappers;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Services;

public class AlertService(IAlertRepository repository, AlertMapper alertMapper) {

    public async Task<Alert> GetById(long id) {
        var alert = await repository.GetByIdAsync(id);
        return alert ?? throw new KeyNotFoundException($"Alert with ID {id} not found");
    }
    
    public async Task<(List<Alert> Items, int TotalCount)> GetAlertsPaginated(int page, int pageSize) {
        var items = await repository.GetAlerts(page, pageSize);
        var total = await repository.GetTotalCount();
        return (items, total);
    }
    
    public async Task<(List<AlertDto> Items, PageInit pageInit, Dictionary<string, int> statusMap)> 
        GetAlertsFilterPaginated(AlertViewFilter filter, int page, int pageSize)
    {
        var query = repository.GetAlertsQuery(filter);
        
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
            .Select(alertMapper.Map)
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