using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class RecipeRepository(NutriFoodDbContext context) : EfCrudRepository<Recipe, int>(context), IRecipeRepository
{
    public Task<Recipe?> GetByIdAndUserIdAsync(int recipeId, short userId, CancellationToken cancellationToken)
    {
        return Context.Recipes
            .AsNoTracking()
            .FirstOrDefaultAsync(recipe =>
                recipe.Id == recipeId &&
                recipe.Active &&
                recipe.FoodMenu != null &&
                recipe.FoodMenu.Active &&
                recipe.FoodMenu.MealPlan != null &&
                recipe.FoodMenu.MealPlan.Active &&
                recipe.FoodMenu.MealPlan.AdequacyPercentage != null &&
                recipe.FoodMenu.MealPlan.AdequacyPercentage.Active &&
                recipe.FoodMenu.MealPlan.AdequacyPercentage.Patient != null &&
                recipe.FoodMenu.MealPlan.AdequacyPercentage.Patient.Active &&
                recipe.FoodMenu.MealPlan.AdequacyPercentage.Patient.UserId == userId,
                cancellationToken);
    }
}
