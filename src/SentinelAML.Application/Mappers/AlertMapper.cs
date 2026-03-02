using SentinelAML.Application.DTOs;
using SentinelAML.Domain.Entities;
using SentinelAML.Domain.Interfaces;

namespace SentinelAML.Application.Mappers;

public class AlertMapper(IDictionaryProvider dictionary, CustomerMapper customerMapper, TransactionMapper transactionMapper) {

    public AlertDto? Map(Alert? alert) {
        if (alert == null)
            return null;

        return new AlertDto(
            Id: alert.Id,
            RiskScore: alert.RiskScore, 
            Rules: alert.Rules,
            Status: alert.Status,  
            Customer: customerMapper.Map(alert.Customer),    
            Transaction: transactionMapper.Map(alert.Transaction),
            CreatedAt: alert.CreatedAt
        );
    }
}