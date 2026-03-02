using SentinelAML.Domain.Entities;
using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Application.Risk.Rules;

public class PepCustomerRule : IRiskRule  {
    // Client PEP → +20
    public void Evaluate(Transaction transaction, Customer customer) {
        throw new NotImplementedException();
    }
}