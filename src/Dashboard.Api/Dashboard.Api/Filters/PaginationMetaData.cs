using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dashboard.Api.Filters;

public class PaginationMetaData
{
    public PaginationMetaData(int totalCount, int pageSize, int pageNumber)
    {
        CurrentPage = pageNumber;
        TotalCount = totalCount;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }
    public int CurrentPage { get; }
    public int TotalCount { get; }
    public int TotalPages { get; }
    public int PageSize { get; }
    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}