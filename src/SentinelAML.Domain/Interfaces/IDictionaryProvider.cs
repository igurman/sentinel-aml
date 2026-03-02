using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Domain.Interfaces;

public interface IDictionaryProvider {
    
    IReadOnlyDictionary<string, DictionaryItem> GetDictionary(string dictName);

    DictionaryItem? GetDictionaryByData(string name, string dictName);
}