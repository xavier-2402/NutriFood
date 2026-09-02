using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class AdequacyPercentageRepository(NutriFoodDbContext context) : EfCrudRepository<AdequacyPercentage, int>(context), IAdequacyPercentageRepository
{
}
