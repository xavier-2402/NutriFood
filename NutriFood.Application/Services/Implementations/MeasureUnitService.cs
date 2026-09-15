using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class MeasureUnitService : IMeasureUnitService
{
    private readonly ICrudRepository<MeasureUnit, short> _repository;

    public MeasureUnitService(ICrudRepository<MeasureUnit, short> repository)
    {
        _repository = repository;
    }

    public async Task<MeasureUnitResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : MeasureUnitMapper.Map(entity);
    }

    public async Task<IReadOnlyList<MeasureUnitResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(MeasureUnitMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<MeasureUnitResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(MeasureUnitMapper.Map).ToList();
    }

    public async Task<MeasureUnitResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : MeasureUnitMapper.Map(entity);
    }

    public async Task<MeasureUnitResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : MeasureUnitMapper.Map(entity);
    }
}