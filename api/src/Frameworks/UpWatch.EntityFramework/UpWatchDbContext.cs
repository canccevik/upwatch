using Microsoft.EntityFrameworkCore;

namespace UpWatch.EntityFramework;

public class UpWatchDbContext : DbContext
{
    protected UpWatchDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyGlobalSoftDeleteFilter();
    }
}
