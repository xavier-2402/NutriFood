using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IUserService
{
    Task<UserResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<UserResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<UserResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<UserResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<UserResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<UserResponse> CreateAsync(UserCreateRequest request, CancellationToken cancellationToken);
    Task<UserResponse?> UpdateAsync(short id, UserUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(short id, short modifiedBy, CancellationToken cancellationToken);
}