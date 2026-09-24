using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodClassificationService : IFoodClassificationService
{
    private readonly ICrudRepository<FoodClassification, short> _repository;

    public FoodClassificationService(ICrudRepository<FoodClassification, short> repository)
    {
        _repository = repository;
    }

    public async Task<FoodClassificationResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodClassificationMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodClassificationResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodClassificationMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodClassificationResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodClassificationMapper.Map).ToList();
    }

    public async Task<FoodClassificationResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodClassificationMapper.Map(entity);
    }

    public async Task<FoodClassificationResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodClassificationMapper.Map(entity);
    }
}