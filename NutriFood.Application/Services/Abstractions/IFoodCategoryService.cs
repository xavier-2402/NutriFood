using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IFoodCategoryService
{
    Task<FoodCategoryResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodCategoryResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodCategoryResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<FoodCategoryResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodCategoryResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}