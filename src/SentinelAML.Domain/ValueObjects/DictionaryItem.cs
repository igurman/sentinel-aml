using SentinelAML.Domain.Constants;

namespace SentinelAML.Domain.ValueObjects;

public class DictionaryItem {
    public string Name { get; init; } = null!;
    
    public DictionaryType Type { get; init; }

    public string? StringValue { get; init; }

    public IReadOnlyDictionary<string, string>? ObjectValue { get; init; }

    public string? Get() {
        return Type != DictionaryType.Value ? null : StringValue;
    }
    
    public string? Get(string? key) {
        if (Type != DictionaryType.Object || ObjectValue == null)
            return null;

        return ObjectValue!.GetValueOrDefault(key);
    }
}