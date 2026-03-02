namespace SentinelAML.Domain.ValueObjects;

public class Money {
    public int Amount { get; set; }
    public required string Currency { get; set; }
}