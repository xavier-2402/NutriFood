using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodCategoryService : IFoodCategoryService
{
    private readonly ICrudRepository<FoodCategory, short> _repository;

    public FoodCategoryService(ICrudRepository<FoodCategory, short> repository)
    {
        _repository = repository;
    }

    public async Task<FoodCategoryResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodCategoryMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodCategoryResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodCategoryMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodCategoryResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodCategoryMapper.Map).ToList();
    }

    public async Task<FoodCategoryResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodCategoryMapper.Map(entity);
    }

    public async Task<FoodCategoryResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodCategoryMapper.Map(entity);
    }
}