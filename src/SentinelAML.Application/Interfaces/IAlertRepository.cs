using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;

namespace SentinelAML.Application.Interfaces;

public interface IAlertRepository : IRepository<Alert> {
    Task<List<Alert>> GetAlerts(int page, int pageSize);
    Task<int> GetTotalCount();
    IQueryable<Alert> GetAlertsQuery(AlertViewFilter filter);
}