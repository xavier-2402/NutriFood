using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IMenuService
{
    Task<MenuResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<MenuResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<MenuResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<MenuResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<MenuResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}