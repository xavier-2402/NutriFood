using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Common.Interfaces;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public class CrudService<TEntity, TId> : ReadOnlyService<TEntity, TId>, ICrudService<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    public CrudService(ICrudRepository<TEntity, TId> repository) : base(repository)
    {
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await ValidateForCreateAsync(entity, cancellationToken);
        return await Repository.AddAsync(entity, cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await ValidateForUpdateAsync(entity, cancellationToken);
        await Repository.UpdateAsync(entity, cancellationToken);
    }

    public virtual Task<bool> DeleteAsync(TId id, short modifiedBy, CancellationToken cancellationToken)
        => Repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);

    protected virtual Task ValidateForCreateAsync(TEntity entity, CancellationToken cancellationToken)
        => Task.CompletedTask;

    protected virtual Task ValidateForUpdateAsync(TEntity entity, CancellationToken cancellationToken)
        => Task.CompletedTask;
}