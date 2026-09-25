using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class MealPlanRepository(NutriFoodDbContext context) : EfCrudRepository<MealPlan, int>(context), IMealPlanRepository
{
    public Task<MealPlan?> GetByIdAndUserIdAsync(int mealPlanId, short userId, CancellationToken cancellationToken)
    {
        return Context.MealPlans
            .AsNoTracking()
            .FirstOrDefaultAsync(mealPlan =>
                mealPlan.Id == mealPlanId &&
                mealPlan.Active &&
                mealPlan.AdequacyPercentage != null &&
                mealPlan.AdequacyPercentage.Active &&
                mealPlan.AdequacyPercentage.Patient != null &&
                mealPlan.AdequacyPercentage.Patient.Active &&
                mealPlan.AdequacyPercentage.Patient.UserId == userId,
                cancellationToken);
    }
}
