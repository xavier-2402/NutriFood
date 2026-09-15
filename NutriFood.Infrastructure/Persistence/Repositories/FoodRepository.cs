using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class FoodRepository(NutriFoodDbContext context) : EfCrudRepository<Food, int>(context), IFoodRepository
{
    public List<Food> FindByCategory(short categoryId)
    {
        return [.. context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodCategoryId == categoryId)];
    }

    public List<Food> FindByClasification(short clasificationId)
    {
        return [.. context.Foods
            .AsNoTracking()
            .Where(x => x.Active && x.FoodClassificationId != null && x.FoodClassificationId == clasificationId)];
    }
}
