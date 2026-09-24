using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class AdequacyPercentageService(IAdequacyPercentageRepository repository) : IAdequacyPercentageService
{
    public async Task<AdequacyPercentageResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : AdequacyPercentageMapper.Map(entity);
    }

    public async Task<IReadOnlyList<AdequacyPercentageResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllAsync(cancellationToken);
        return [.. entities.Select(AdequacyPercentageMapper.Map)];
    }

    public async Task<IReadOnlyList<AdequacyPercentageResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await repository.GetAllActiveAsync(cancellationToken);
        return [.. entities.Select(AdequacyPercentageMapper.Map)];
    }

    public async Task<AdequacyPercentageResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : AdequacyPercentageMapper.Map(entity);
    }

    public async Task<AdequacyPercentageResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : AdequacyPercentageMapper.Map(entity);
    }

    public async Task<AdequacyPercentageResponse> CreateAsync(AdequacyPercentageCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = AdequacyPercentageMapper.ToEntity(request);
        var created = await repository.AddAsync(entity, cancellationToken);
        return AdequacyPercentageMapper.Map(created);
    }

    public async Task<AdequacyPercentageResponse?> UpdateAsync(int id, AdequacyPercentageUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = AdequacyPercentageMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await repository.UpdateAsync(entity, cancellationToken);
        return AdequacyPercentageMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}