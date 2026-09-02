using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class FoodCategoryMapper
{
    public static FoodCategoryResponse Map(FoodCategory entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Active);
}