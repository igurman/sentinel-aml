using SentinelAML.Domain.Enums;

namespace SentinelAML.Domain.Entities;

public class Alert {
    public long Id { get; private set; }
    public long CustomerId { get; private set; }
    public long TransactionId { get; private set; }
    public int RiskScore { get; private set; }
    public List<string> Rules { get; private set; }
    public AlertStatus Status { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public Customer? Customer { get; private set; }
    public Transaction? Transaction { get; private set; }

    public Alert(long id, long customerId, long transactionId, int riskScore, List<string> rules, 
        AlertStatus status, DateTimeOffset createdAt) {
        Id = id;
        CustomerId = customerId;
        TransactionId = transactionId;
        RiskScore = riskScore;
        Rules = rules;
        Status = status;
        CreatedAt = createdAt;
    }
}