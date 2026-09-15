using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodMenuService : IFoodMenuService
{
    private readonly IFoodMenuRepository _repository;

    public FoodMenuService(IFoodMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<FoodMenuResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodMenuResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodMenuMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodMenuResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodMenuMapper.Map).ToList();
    }

    public async Task<FoodMenuResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<FoodMenuResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<FoodMenuResponse> CreateAsync(FoodMenuCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = FoodMenuMapper.ToEntity(request);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return FoodMenuMapper.Map(created);
    }

    public async Task<FoodMenuResponse?> UpdateAsync(int id, FoodMenuUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = FoodMenuMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return FoodMenuMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}