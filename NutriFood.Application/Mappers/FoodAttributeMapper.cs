using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class FoodAttributeMapper
{
    public static FoodAttributeResponse Map(FoodAttribute entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Description,
        entity.MeasureUnitId,
        entity.Active);
}