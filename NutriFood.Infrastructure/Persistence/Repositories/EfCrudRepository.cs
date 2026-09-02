using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Common.Interfaces;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public class EfCrudRepository<TEntity, TId> : ICrudRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>, IActivableEntity, ICodeEntity
{
    public EfCrudRepository(NutriFoodDbContext context)
    {
        Context = context;
        _set = context.Set<TEntity>();
    }

    protected NutriFoodDbContext Context { get; }
    private readonly DbSet<TEntity> _set;

    public async Task<TEntity?> GetByIdAsync(TId id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _set.AsNoTracking().FirstOrDefaultAsync(e => e.Id!.Equals(id), cancellationToken);

        if (entity is null || (!includeInactive && !entity.Active))
        {
            return null;
        }

        return entity;
    }

    public Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken) => GetByIdAsync(id, false, cancellationToken);

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = _set.AsNoTracking();
        return await query
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(bool includeInactive, CancellationToken cancellationToken)
    {
        var query = _set.AsNoTracking();
        return await (includeInactive ? query : query.Where(entity => entity.Active))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var query = _set.AsNoTracking().Where(entity => entity.Active);
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var query = _set.AsNoTracking().Where(entity => entity.Code == code);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }


    public async Task<TEntity?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var query = _set.AsNoTracking().Where(entity => entity.Code == code && entity.Active);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _set.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _set.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SoftDeleteAsync(TId id, short modifiedBy, CancellationToken cancellationToken)
    {
        var entity = await _set.FindAsync([id], cancellationToken);

        if (entity is null || !entity.Active)
        {
            return false;
        }

        entity.Active = false;
        if (entity is IAuditableEntity auditable)
        {
            auditable.ModDate = DateTime.UtcNow;
            auditable.ModUsr = modifiedBy;
        }

        await Context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
