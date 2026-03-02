namespace SentinelAML.Application.Risk;

public record RuleDictionary(string Name, string Color, int Level)
{
    private static readonly RuleDictionary LargeTransaction = new("Large Transaction", "warning", 1);
    private static readonly RuleDictionary HighRiskCountry = new("High Risk Country", "danger", 2);
    private static readonly RuleDictionary HighFrequency = new("High Frequency", "warning", 1);
    private static readonly RuleDictionary PepCustomer = new("PEP Customer", "danger", 1);
    
    private static readonly Dictionary<string, RuleDictionary> AllRules = new()
    {
        [LargeTransaction.Name] = LargeTransaction,
        [HighRiskCountry.Name] = HighRiskCountry,
        [HighFrequency.Name] = HighFrequency,
        [PepCustomer.Name] = PepCustomer
    };
    
    public static RuleDictionary? FromName(string name) =>
        AllRules.GetValueOrDefault(name);
    
    public static List<RuleDictionary> GetRules() =>
        AllRules.Values.ToList();
}
