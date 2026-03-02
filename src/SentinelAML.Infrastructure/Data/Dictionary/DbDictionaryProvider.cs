using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using SentinelAML.Domain.Constants;
using SentinelAML.Domain.Entities;
using SentinelAML.Domain.Interfaces;
using SentinelAML.Domain.ValueObjects;

namespace SentinelAML.Infrastructure.Data.Dictionary;

public class DbDictionaryProvider : IDictionaryProvider {
    private readonly AppDbContext _context;

    // dictName -> (name -> DictionaryItem)
    private readonly Dictionary<string, Dictionary<string, DictionaryItem>> _cache = new(StringComparer.OrdinalIgnoreCase);

    private bool _initialized;
    private readonly object _lock = new();

    public DbDictionaryProvider(AppDbContext context) {
        _context = context;
    }

    private void EnsureInitialized() {
        if (_initialized) return;

        lock (_lock) {
            if (_initialized) return;

            var records = _context.Set<DictionaryEntity>()
                                  .AsNoTracking()
                                  .ToList();

            foreach (var record in records) {
                if (!_cache.ContainsKey(record.Dict)) {
                    _cache[record.Dict] = new Dictionary<string, DictionaryItem>(StringComparer.OrdinalIgnoreCase);
                }
                var item = MapToRuntime(record);
                _cache[record.Dict][record.Name] = item;
            }
            _initialized = true;
        }
    }

    private static DictionaryItem MapToRuntime(DictionaryEntity record) {
        if (record.Type == DictionaryType.Value) {
            return new DictionaryItem {
                Name = record.Name,
                Type = record.Type,
                StringValue = record.Value
            };
        }

        var parsed = JsonSerializer.Deserialize<Dictionary<string, string>>(record.Value)
                     ?? new Dictionary<string, string>();

        return new DictionaryItem {
            Name = record.Name,
            Type = record.Type,
            ObjectValue = parsed
        };
    }

    public IReadOnlyDictionary<string, DictionaryItem> GetDictionary(string dictName) {
        EnsureInitialized();

        return _cache.TryGetValue(dictName, out var dict)
            ? dict
            : new Dictionary<string, DictionaryItem>();
    }

    public DictionaryItem? GetDictionaryByData(string name, string dictName) {
        EnsureInitialized();

        if (_cache.TryGetValue(dictName, out var dict) &&
            dict.TryGetValue(name, out var item)) {
            return item;
        }

        return null;
    }
}