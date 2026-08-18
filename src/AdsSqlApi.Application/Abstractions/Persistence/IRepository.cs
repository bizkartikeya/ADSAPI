using AdsSqlApi.Domain.Common;

namespace AdsSqlApi.Application.Abstractions.Persistence;

public interface IRepository<T>
    where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    void Update(T entity);

    void Delete(T entity);
}
