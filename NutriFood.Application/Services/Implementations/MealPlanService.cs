using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class MealPlanService : IMealPlanService
{
    private readonly IMealPlanRepository _repository;

    public MealPlanService(IMealPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<MealPlanResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : MealPlanMapper.Map(entity);
    }

    public async Task<IReadOnlyList<MealPlanResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(MealPlanMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<MealPlanResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(MealPlanMapper.Map).ToList();
    }

    public async Task<MealPlanResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : MealPlanMapper.Map(entity);
    }

    public async Task<MealPlanResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : MealPlanMapper.Map(entity);
    }

    public async Task<MealPlanResponse> CreateAsync(MealPlanCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = MealPlanMapper.ToEntity(request);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return MealPlanMapper.Map(created);
    }

    public async Task<MealPlanResponse?> UpdateAsync(int id, MealPlanUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = MealPlanMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return MealPlanMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}