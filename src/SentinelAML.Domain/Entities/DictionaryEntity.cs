using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SentinelAML.Domain.Constants;

namespace SentinelAML.Domain.Entities;

[Table("Dictionaries")]
public class DictionaryEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    public string Value { get; set; } = null!;
    
    [Required]
    [MaxLength(100)]
    public string Dict { get; set; } = null!;
    
    [Required]
    public DictionaryType Type { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
}