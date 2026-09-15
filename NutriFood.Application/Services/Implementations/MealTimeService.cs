using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class MealTimeService : IMealTimeService
{
    private readonly ICrudRepository<MealTime, short> _repository;

    public MealTimeService(ICrudRepository<MealTime, short> repository)
    {
        _repository = repository;
    }

    public async Task<MealTimeResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : MealTimeMapper.Map(entity);
    }

    public async Task<IReadOnlyList<MealTimeResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(MealTimeMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<MealTimeResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(MealTimeMapper.Map).ToList();
    }

    public async Task<MealTimeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : MealTimeMapper.Map(entity);
    }

    public async Task<MealTimeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : MealTimeMapper.Map(entity);
    }
}