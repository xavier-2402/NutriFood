using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Domain.Repositories;

public interface ICrudRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    Task<TEntity?> GetByIdAsync(TId id, bool includeInactive, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<TEntity?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> SoftDeleteAsync(TId id, short modifiedBy, CancellationToken cancellationToken);
}
