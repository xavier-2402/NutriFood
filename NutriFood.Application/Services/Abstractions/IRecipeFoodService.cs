using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IRecipeFoodService
{
    Task<RecipeFoodResponse> CreateAsync(RecipeFoodCreateRequest request, CancellationToken cancellationToken);
}
