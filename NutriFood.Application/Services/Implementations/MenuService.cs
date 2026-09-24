using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class MenuService : IMenuService
{
    private readonly ICrudRepository<Menu, short> _repository;

    public MenuService(ICrudRepository<Menu, short> repository)
    {
        _repository = repository;
    }

    public async Task<MenuResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : MenuMapper.Map(entity);
    }

    public async Task<IReadOnlyList<MenuResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(MenuMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<MenuResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(MenuMapper.Map).ToList();
    }

    public async Task<MenuResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : MenuMapper.Map(entity);
    }

    public async Task<MenuResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : MenuMapper.Map(entity);
    }
}