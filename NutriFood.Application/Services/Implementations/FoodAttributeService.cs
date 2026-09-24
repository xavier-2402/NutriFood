using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodAttributeService : IFoodAttributeService
{
    private readonly ICrudRepository<FoodAttribute, short> _repository;

    public FoodAttributeService(ICrudRepository<FoodAttribute, short> repository)
    {
        _repository = repository;
    }

    public async Task<FoodAttributeResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodAttributeMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodAttributeResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodAttributeMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodAttributeResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodAttributeMapper.Map).ToList();
    }

    public async Task<FoodAttributeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodAttributeMapper.Map(entity);
    }

    public async Task<FoodAttributeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodAttributeMapper.Map(entity);
    }
}