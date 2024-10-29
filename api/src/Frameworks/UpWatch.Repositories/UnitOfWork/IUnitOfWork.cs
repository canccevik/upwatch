namespace UpWatch.Repositories.UnitOfWork;

public interface IUnitOfWork<TContext> : IUnitOfWork
{
}

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IDatabaseTransaction BeginTransaction();
    Task<IDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}
