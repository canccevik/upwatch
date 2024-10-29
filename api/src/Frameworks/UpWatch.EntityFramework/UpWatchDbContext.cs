using Microsoft.EntityFrameworkCore;

namespace UpWatch.EntityFramework;

public class UpWatchDbContext : DbContext
{
    protected UpWatchDbContext(DbContextOptions options) : base(options)
    {
    }
}
