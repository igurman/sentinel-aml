using SentinelAML.Domain.Enums;

namespace SentinelAML.Domain.Entities;

public class Customer {
    public long Id { get; set; }
    public string Name { get; set; }
    public CountryType Country { get; set; }
    public bool IsPep { get; set; }
    public RiskLevel RiskLevel { get; set; }
    public DateOnly CreatedAt { get; set; }

    public Customer(long id, string name, CountryType country, bool isPep, RiskLevel riskLevel, DateOnly createdAt) {
        Id = id;
        Name = name;
        Country = country;
        IsPep = isPep;
        RiskLevel = riskLevel;
        CreatedAt = createdAt;
    }
    
    // PromoteRiskLevel()
}