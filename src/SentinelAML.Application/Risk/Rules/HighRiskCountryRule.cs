using SentinelAML.Domain.Entities;
using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Application.Risk.Rules;

public class HighRiskCountryRule : IRiskRule  {
    // CountryList → +30
    public void Evaluate(Transaction transaction, Customer customer) {
        throw new NotImplementedException();
    }
}