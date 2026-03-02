namespace SentinelAML.Application.DTOs;

public record PaginationRequest(
    int CurrentPage,
    int PageSize
);