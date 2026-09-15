using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodService : IFoodService
{
    private readonly IFoodRepository _repository;

    public FoodService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task<FoodResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodMapper.Map).ToList();
    }

    public async Task<FoodResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMapper.Map(entity);
    }

    public async Task<FoodResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMapper.Map(entity);
    }

    public async Task<FoodResponse> CreateAsync(FoodCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = FoodMapper.ToEntity(request);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return FoodMapper.Map(created);
    }

    public async Task<FoodResponse?> UpdateAsync(int id, FoodUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = FoodMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return FoodMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);

    public List<FoodResponse> GetByCategory(short categoryId)
    {
        return _repository.FindByCategory(categoryId).Select(FoodMapper.Map).ToList();
    }

    public List<FoodResponse> GetByClassification(short classificationId)
    {
        return _repository.FindByClasification(classificationId).Select(FoodMapper.Map).ToList();
    }
}