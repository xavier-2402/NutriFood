using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IFoodAttributeService
{
    Task<FoodAttributeResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodAttributeResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodAttributeResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<FoodAttributeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodAttributeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}