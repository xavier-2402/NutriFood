using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IFoodService
{
    Task<FoodResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<FoodResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<FoodResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<FoodResponse> CreateAsync(FoodCreateRequest request, CancellationToken cancellationToken);
    Task<FoodResponse?> UpdateAsync(int id, FoodUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
    List<FoodResponse> GetByCategory(short categoryId);
    List<FoodResponse> GetByClassification(short classificationId);
}