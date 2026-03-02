using SentinelAML.Domain.Entities;
using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Application.Risk.Rules;

public class LargeTransactionRule : IRiskRule  {
    // Amount > 10 000 → +50
    public void Evaluate(Transaction transaction, Customer customer) {
        throw new NotImplementedException();
    }
}