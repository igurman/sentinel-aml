namespace SentinelAML.Application.DTOs;

public record PageInit(
    int CurrentPage,
    int PageSize,
    int TotalPages,
    int TotalItems
);