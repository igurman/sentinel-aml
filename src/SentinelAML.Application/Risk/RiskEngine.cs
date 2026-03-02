using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Application.Risk;

public class RiskEngine : IRiskEngine {

    public RiskScore CalculateRiskScore(List<IRiskRule> riskRules) {
        throw new NotImplementedException();
    }
}