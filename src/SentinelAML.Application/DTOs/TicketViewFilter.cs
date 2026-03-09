namespace SentinelAML.Application.DTOs;

public class TicketViewFilter {
    public string? Name { get; set; }
    public string? Priority { get; set; }
    public string? Assigned { get; set; }
    public string? Status { get; set; }
    
    public void Clean() {
        Name = null;
        Priority = null;
        Assigned = null;
        Status = null;
    }
}