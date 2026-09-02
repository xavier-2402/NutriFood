using NutriFood.Domain.Common.Interfaces;

namespace NutriFood.Application.Services.Abstractions;

public interface ICrudService<TEntity, TId> : IReadOnlyService<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(TId id, short modifiedBy, CancellationToken cancellationToken);
}