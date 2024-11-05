using Microsoft.EntityFrameworkCore;

namespace UpWatch.Data.Pagination;

public static class PaginationExtension
{
    public static async Task<PagedResult<T>> Paginate<T>(
        this IQueryable<T> query,
        int page,
        int limit
    )
    {
        var skip = (page - 1) * limit;
        var items = await query.Skip(skip).Take(limit + 1).ToListAsync();
        
        var hasNextPage = items.Count > limit;
        if (hasNextPage)
            items.RemoveAt(items.Count - 1);

        return new PagedResult<T>
        {
            Page = page,
            Limit = limit,
            HasNextPage = hasNextPage,
            Items = items
        };
    }
}
