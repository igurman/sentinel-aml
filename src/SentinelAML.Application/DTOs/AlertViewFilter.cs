namespace SentinelAML.Application.DTOs;

public class AlertViewFilter {
    public string? Name { get; set; }
    public string? RiscScore { get; set; }
    public string? Status { get; set; }
    public string? Date { get; set; }
    
    public void Clean() {
        Name = null;
        RiscScore = null;
        Status = null;
        Date = null;
    }
}