using Microsoft.EntityFrameworkCore;
using SentinelAML.Application.DTOs;
using SentinelAML.Application.Interfaces;
using SentinelAML.Domain.Entities;
using SentinelAML.Domain.Enums;
using SentinelAML.Infrastructure.Data;

namespace SentinelAML.Infrastructure.Repositories;

public class AlertRepository(AppDbContext context): IAlertRepository {

    public async Task<Alert?> GetByIdAsync(long id) => await context.Alerts
        .Include(a => a.Customer)
        .Include(a => a.Transaction)
        .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<List<Alert>> GetAllAsync() => 
        await context.Alerts
            .Include(a => a.Transaction)
            .Include(a => a.Customer)
            .ToListAsync();

    public async Task AddAsync(Alert entity) => await context.Alerts.AddAsync(entity);

    public void Update(Alert entity) => context.Alerts.Update(entity);

    public void Remove(Alert entity) => context.Alerts.Remove(entity);
    
    public async Task<List<Alert>> GetAlerts(int page, int pageSize) {
        return await context.Alerts
            .OrderBy(alert => alert.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<int> GetTotalCount() => await context.Alerts.CountAsync();
    
    public IQueryable<Alert> GetAlertsQuery(AlertViewFilter filter) {
        var query = context.Alerts
            .AsNoTracking()
            .Include(a => a.Customer)
            .Include(a => a.Transaction)
            .AsQueryable();
        
        query = AddNameCondition(query, filter);
        query = AddRiscScoreCondition(query, filter);
        query = AddStatusCondition(query, filter);
        query = AddDateCondition(query, filter);
        
        return query;
    }
    
    private static IQueryable<Alert> AddNameCondition(IQueryable<Alert> query, AlertViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Name)) return query;
        
        return query.Where(a =>
            a.Customer != null 
            && a.Customer.Name.Contains(filter.Name));
    }
    
    private static IQueryable<Alert> AddRiscScoreCondition(IQueryable<Alert> query, AlertViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.RiscScore)) return query;
        
        var score = filter.RiscScore switch {
            "high" => (start: 70, end: 100),
            "medium" => (start: 40, end: 70),
            "low" => (start: 0, end: 40),
            _ => (start: 0, end: 100)
        };

        return query.Where(a => 
            a.RiskScore >= score.start 
            && a.RiskScore < score.end);
    }
    
    private static IQueryable<Alert> AddStatusCondition(IQueryable<Alert> query, AlertViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Status)) return query;
        
        var status = filter.Status switch {
            "open" => AlertStatus.Open,
            "in_review" => AlertStatus.InReview,
            "closed" => AlertStatus.Closed,
            "false_positive" => AlertStatus.FalsePositive,
            _ => AlertStatus.Open
        };

        return query.Where(a => a.Status == status);
    }

    private static IQueryable<Alert> AddDateCondition(IQueryable<Alert> query, AlertViewFilter filter) {
        if (string.IsNullOrWhiteSpace(filter.Date)) return query;
        
        var date = filter.Date switch {
            "1" => DateTimeOffset.Now.AddDays(-1),
            "7" => DateTimeOffset.Now.AddDays(-7),
            "30" => DateTimeOffset.Now.AddDays(-30),
            "120" => DateTimeOffset.Now.AddDays(-120),
            _ => DateTimeOffset.Now
        };
        
        return query.Where(a => a.CreatedAt > date);
    }
}
