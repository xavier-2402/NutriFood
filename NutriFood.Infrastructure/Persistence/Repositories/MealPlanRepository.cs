using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class MealPlanRepository(NutriFoodDbContext context) : EfCrudRepository<MealPlan, int>(context), IMealPlanRepository
{
}
