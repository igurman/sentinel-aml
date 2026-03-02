using SentinelAML.Domain.Entities;

namespace SentinelAML.Domain.ValueObjects;

public interface IRiskRule {
    void Evaluate(Transaction transaction, Customer customer);
}