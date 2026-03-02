using SentinelAML.Domain.Entities;
using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Application.Risk.Rules;

public class HighFrequencyRule : IRiskRule {
    // > 3/1min → +40
    public void Evaluate(Transaction transaction, Customer customer) {
        throw new NotImplementedException();
    }
}