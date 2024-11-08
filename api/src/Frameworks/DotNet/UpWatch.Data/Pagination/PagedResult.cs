namespace UpWatch.Data.Pagination;

public class PagedResult<T>
{
    public int Page { get; set; }
    public int Limit { get; set; }
    public bool HasNextPage { get; set; }
    public required List<T> Items { get; set; }
}
