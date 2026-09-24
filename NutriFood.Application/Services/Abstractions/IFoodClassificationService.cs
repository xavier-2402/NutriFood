using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IFoodClassificationService
{
    Task<FoodClassificationResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodClassificationResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodClassificationResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<FoodClassificationResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodClassificationResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}