namespace SentinelAML.Application.DTOs;

public class CardDto {
    public string? Title {get; set;}
    public string Value { get; set; } = "0";
    public string? Color {get; set;}
    public string? Description { get; set; }
    public string? Icon {get; set;}
    public string? Status {get; set;}
    
    public static Builder builder() => new();
    
    public class Builder {
        private string? _title;
        private string _value = "0";
        private string? _color;
        private string? _description;
        private string? _icon;
        private string? _status;
        
        public Builder Title(string? value) {
            _title = value;
            return this;
        }
        
        public Builder Value(string value) {
            _value = value;
            return this;
        }
        
        public Builder Color(string? value) {
            _color = value;
            return this;
        }
        
        public Builder Description(string? value) {
            _description = value;
            return this;
        }
        
        public Builder Icon(string? value) {
            _icon = value;
            return this;
        }
        
        public Builder Status(string? value) {
            _status = value;
            return this;
        }

        public CardDto Build() {
            return new CardDto {
                Title = _title,
                Value = _value,
                Color = _color,
                Description = _description,
                Icon = _icon,
                Status = _status
            };
        }
    }
}