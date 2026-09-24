using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IMealTimeService
{
    Task<MealTimeResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<MealTimeResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<MealTimeResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<MealTimeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<MealTimeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}