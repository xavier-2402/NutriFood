using NutriFood.Domain.Entities;

namespace NutriFood.Domain.Repositories;

public interface IRecipeFoodRepository
{
    Task<RecipeFood> AddAsync(RecipeFood entity, CancellationToken cancellationToken);
}
