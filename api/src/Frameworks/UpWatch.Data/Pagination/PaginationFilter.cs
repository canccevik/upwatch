namespace UpWatch.Data.Pagination;

public class PaginationFilter
{
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
    public bool HasNextPage { get; set; }
}
