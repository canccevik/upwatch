namespace UpWatch.Repositories.UnitOfWork;

public interface IDatabaseTransaction: IDisposable, IAsyncDisposable
{
    void Commit();
    Task CommitAsync(CancellationToken cancellationToken = default);

    void Rollback();
    Task RollbackAsync(CancellationToken cancellationToken = default);
}
