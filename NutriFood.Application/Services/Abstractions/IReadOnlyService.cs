using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Application.Services.Abstractions;

public interface IReadOnlyService<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    Task<TEntity?> GetByIdAsync(TId id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<TEntity?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}