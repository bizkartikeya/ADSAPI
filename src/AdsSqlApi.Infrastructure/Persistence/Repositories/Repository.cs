using AdsSqlApi.Application.Abstractions.Persistence;
using AdsSqlApi.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AdsSqlApi.Infrastructure.Persistence.Repositories;

public sealed class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private readonly DbSet<T> _set;

    public Repository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _set = dbContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _set.SingleOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _set.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(T entity)
    {
        _set.Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _set.Remove(entity);
        _dbContext.SaveChanges();
    }
}
