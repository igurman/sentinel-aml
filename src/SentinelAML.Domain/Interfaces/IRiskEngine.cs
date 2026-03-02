namespace SentinelAML.Domain.ValueObjects;

public interface IRiskEngine {
    RiskScore CalculateRiskScore(List<IRiskRule> riskRules);
}