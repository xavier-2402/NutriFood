using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class FoodMenuRepository(NutriFoodDbContext context) : EfCrudRepository<FoodMenu, int>(context), IFoodMenuRepository
{
    public Task<FoodMenu?> GetByIdAndUserIdAsync(int foodMenuId, short userId, CancellationToken cancellationToken)
    {
        return Context.FoodMenus
            .AsNoTracking()
            .FirstOrDefaultAsync(foodMenu =>
                foodMenu.Id == foodMenuId &&
                foodMenu.Active &&
                foodMenu.MealPlan != null &&
                foodMenu.MealPlan.Active &&
                foodMenu.MealPlan.AdequacyPercentage != null &&
                foodMenu.MealPlan.AdequacyPercentage.Active &&
                foodMenu.MealPlan.AdequacyPercentage.Patient != null &&
                foodMenu.MealPlan.AdequacyPercentage.Patient.Active &&
                foodMenu.MealPlan.AdequacyPercentage.Patient.UserId == userId,
                cancellationToken);
    }
}
