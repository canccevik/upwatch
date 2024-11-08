using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UpWatch.Repositories.Repository;

namespace UpWatch.EntityFramework.Repositories;

public class EfQueryRepository<TContext, TEntity> : IQueryRepository<TEntity>
    where TContext : DbContext where TEntity : class
{
    protected readonly TContext _dbContext; 
    protected readonly DbSet<TEntity> _dbSet;

    public EfQueryRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }
    
    public IQueryable<TEntity> Get()
        => _dbSet;

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        => _dbSet.Where(condition);

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.Where(condition).ToListAsync();

    public TEntity GetByKey(object key)
        => _dbSet.Find(key);

    public async Task<TEntity> GetByKeyAsync(object key)
        => await _dbSet.FindAsync(key);

    public bool Any()
        => _dbSet.Any();

    public bool Any(Expression<Func<TEntity, bool>> condition)
        => _dbSet.Any(condition);

    public async Task<bool> AnyAsync()
        => await _dbSet.AnyAsync();

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.AnyAsync(condition);

    public long Count()
        => _dbSet.Count();

    public long Count(Expression<Func<TEntity, bool>> condition)
        => _dbSet.Count(condition);

    public async Task<long> CountAsync()
        => await _dbSet.CountAsync();

    public async Task<long> CountAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.CountAsync(condition);

    public TEntity First()
        => _dbSet.First();

    public TEntity First(Expression<Func<TEntity, bool>> condition)
        => _dbSet.First(condition);

    public async Task<TEntity> FirstAsync()
        => await _dbSet.FirstAsync();

    public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.FirstAsync(condition);

    public TEntity FirstOrDefault()
        => _dbSet.FirstOrDefault();

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> condition)
        => _dbSet.FirstOrDefault(condition);

    public async Task<TEntity> FirstOrDefaultAsync()
        => await _dbSet.FirstOrDefaultAsync();

    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.FirstOrDefaultAsync(condition);

    public TEntity Single()
        => _dbSet.Single();

    public TEntity Single(Expression<Func<TEntity, bool>> condition)
        => _dbSet.Single(condition);

    public async Task<TEntity> SingleAsync()
        => await _dbSet.SingleAsync();

    public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.SingleAsync(condition);

    public TEntity SingleOrDefault()
        => _dbSet.SingleOrDefault();

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> condition)
        => _dbSet.SingleOrDefault();

    public async Task<TEntity> SingleOrDefaultAsync()
        => await _dbSet.SingleOrDefaultAsync();
        
    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> condition)
        => await _dbSet.SingleOrDefaultAsync(condition);
}
