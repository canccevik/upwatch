using System.Linq.Expressions;
using System.Net;
using Microsoft.EntityFrameworkCore;
using UpWatch.Data.AutoWrapper;
using UpWatch.Domain;
using UpWatch.Repositories.Repository;

namespace UpWatch.EntityFramework.Repositories;

public class EfRepository<TContext, TEntity> : EfQueryRepository<TContext, TEntity>, IRepository<TEntity>
    where TContext : DbContext where TEntity : class
{
    public EfRepository(TContext dbContext) : base(dbContext)
    {
    }
    
    public TEntity Add(TEntity item)
        => _dbContext.Add(item).Entity;
        
    public async Task<TEntity> AddAsync(TEntity item)
        => (await _dbContext.AddAsync(item)).Entity;

    public void AddRange(IEnumerable<TEntity> items)
        => _dbContext.AddRange(items);

    public async Task AddRangeAsync(IEnumerable<TEntity> items)
        => await _dbContext.AddRangeAsync(items);

    public TEntity Update(object key, TEntity item)
    {
        var entity = _dbSet.Find(key);
        if (entity == null)
            throw new ApiException($"Item not found: {item}", HttpStatusCode.NotFound);
            
        _dbContext.Entry(entity).CurrentValues.SetValues(item);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(object key, TEntity item)
    {
        var entity = await _dbSet.FindAsync(key);
        if (entity == null)
            throw new ApiException($"Item not found: {item}", HttpStatusCode.NotFound);
            
        _dbContext.Entry(entity).CurrentValues.SetValues(item);
        return entity;
    }

    public void Delete(object key)
    {
        var entity = _dbSet.Find(key);
        
        switch (entity)
        {
            case null:
                throw new ApiException($"Item not found: {key}", HttpStatusCode.NotFound);
            case ISoftDeletable softDeletableEntity:
                softDeletableEntity.IsDeleted = true;
                break;
            default:
                _dbContext.Remove(entity);
                break;
        }
    }
        
    public void Delete(Expression<Func<TEntity, bool>> condition)
    {
        var entities = _dbSet.Where(condition).ToList();

        foreach (var entity in entities)
        {
            if (entity is ISoftDeletable softDeletableEntity)
                softDeletableEntity.IsDeleted = true;
            else
                _dbContext.Remove(entity);
        }
    }

    public async Task DeleteAsync(object key)
    {
        var entity =  await _dbSet.FindAsync(key);
        
        switch (entity)
        {
            case null:
                throw new ApiException($"Item not found: {key}", HttpStatusCode.NotFound);
            case ISoftDeletable softDeletableEntity:
                softDeletableEntity.IsDeleted = true;
                break;
            default:
                _dbContext.Remove(entity);
                break;
        }
    }

    public async Task DeleteAsync(Expression<Func<TEntity, bool>> condition)
    {
        var entities = await _dbSet.Where(condition).ToListAsync();

        foreach (var entity in entities)
        {
            if (entity is ISoftDeletable softDeletableEntity)
                softDeletableEntity.IsDeleted = true;
            else
                _dbContext.Remove(entity);
        }
    }
}
