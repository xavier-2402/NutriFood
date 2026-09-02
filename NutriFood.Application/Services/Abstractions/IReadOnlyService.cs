using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Application.Services.Abstractions;

public interface IReadOnlyService<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TId id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken);
}