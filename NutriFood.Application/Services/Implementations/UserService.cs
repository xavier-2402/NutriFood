using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : UserMapper.Map(entity);
    }

    public async Task<IReadOnlyList<UserResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(UserMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<UserResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(UserMapper.Map).ToList();
    }

    public async Task<UserResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : UserMapper.Map(entity);
    }

    public async Task<UserResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : UserMapper.Map(entity);
    }

    public async Task<UserResponse> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken)
    {
        var entity = UserMapper.ToEntity(request);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return UserMapper.Map(created);
    }

    public async Task<UserResponse?> UpdateAsync(short id, UserUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = UserMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return UserMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(short id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}