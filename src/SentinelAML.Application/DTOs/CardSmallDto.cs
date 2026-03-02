using SentinelAML.Domain.Enums;

namespace SentinelAML.Application.DTOs;

public class CardSmallDto {
    public string Title {get; set;}
    public string Value {get; set;}
    public string Color {get; set;}
    public AlertStatus Status {get; set;}

    public CardSmallDto(string title, string value, string color, AlertStatus status) {
        Title = title;
        Value = value;
        Color = color;
        Status = status;
    }
}