using NutriFood.Domain.Entities;
namespace NutriFood.Domain.Repositories;
public interface IRecipeRepository : ICrudRepository<Recipe, int>
{
    Task<Recipe?> GetByIdAndUserIdAsync(int recipeId, short userId, CancellationToken cancellationToken);
}
