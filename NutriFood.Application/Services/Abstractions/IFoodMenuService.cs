using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IFoodMenuService
{
    Task<FoodMenuResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodMenuResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodMenuResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<FoodMenuResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodMenuResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodMenuResponse> CreateAsync(FoodMenuCreateRequest request, CancellationToken cancellationToken);
    Task<FoodMenuResponse?> UpdateAsync(int id, FoodMenuUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
}