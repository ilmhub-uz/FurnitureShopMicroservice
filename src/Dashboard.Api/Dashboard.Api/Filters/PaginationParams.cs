namespace Dashboard.Api.Filters;

public class PaginationParams
{
    private const int MaxPageSize = 500;
    private const int MinPageNumber = 1;

    private int _pagesize = 5;
    private int _pageNumber = 1;

    public int Size
    {
        get => _pagesize > MaxPageSize ? MaxPageSize : _pagesize <= 0 ? 1 : _pagesize;
        set => _pagesize = value;
    }

    public int Page
    {
        get => _pageNumber < MinPageNumber ? MinPageNumber : _pageNumber;
        set => _pageNumber = value;
    }
}