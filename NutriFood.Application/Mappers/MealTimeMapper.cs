using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class MealTimeMapper
{
    public static MealTimeResponse Map(MealTime entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Active);
}