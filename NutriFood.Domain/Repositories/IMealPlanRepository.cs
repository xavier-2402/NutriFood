using NutriFood.Domain.Entities;
namespace NutriFood.Domain.Repositories;
public interface IMealPlanRepository : ICrudRepository<MealPlan, int>
{
    Task<MealPlan?> GetByIdAndUserIdAsync(int mealPlanId, short userId, CancellationToken cancellationToken);
}
