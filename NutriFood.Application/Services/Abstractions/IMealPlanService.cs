using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IMealPlanService
{
    Task<MealPlanResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<MealPlanResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<MealPlanResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<MealPlanResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<MealPlanResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<MealPlanResponse> CreateAsync(MealPlanCreateRequest request, CancellationToken cancellationToken);
    Task<MealPlanResponse?> UpdateAsync(int id, MealPlanUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
}