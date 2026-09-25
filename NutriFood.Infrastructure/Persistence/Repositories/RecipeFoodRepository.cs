using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class RecipeFoodRepository(NutriFoodDbContext context) : IRecipeFoodRepository
{
    public async Task<RecipeFood> AddAsync(RecipeFood entity, CancellationToken cancellationToken)
    {
        await context.RecipeFoods.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}