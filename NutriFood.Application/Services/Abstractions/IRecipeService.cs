using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IRecipeService
{
    Task<RecipeResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<RecipeResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<RecipeResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<RecipeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<RecipeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<RecipeResponse> CreateAsync(RecipeCreateRequest request, CancellationToken cancellationToken);
    Task<RecipeResponse?> UpdateAsync(int id, RecipeUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
}