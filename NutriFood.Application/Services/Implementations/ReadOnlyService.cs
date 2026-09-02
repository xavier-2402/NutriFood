using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Interfaces;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public class ReadOnlyService<TEntity, TId> : IReadOnlyService<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    protected readonly ICrudRepository<TEntity, TId> Repository;

    public ReadOnlyService(ICrudRepository<TEntity, TId> repository)
    {
        Repository = repository;
    }

    public virtual Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
        => Repository.GetByIdAsync(id, cancellationToken);

    public virtual Task<TEntity?> GetByIdAsync(TId id, bool includeInactive, CancellationToken cancellationToken)
        => Repository.GetByIdAsync(id, includeInactive, cancellationToken);

    public virtual Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        => Repository.GetAllAsync(cancellationToken);

    public virtual Task<IReadOnlyList<TEntity>> GetAllAsync(bool includeInactive, CancellationToken cancellationToken)
        => Repository.GetAllAsync(includeInactive, cancellationToken);

    public virtual Task<IReadOnlyList<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
        => Repository.GetAllActiveAsync(cancellationToken);
}