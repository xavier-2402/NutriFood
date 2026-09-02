using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class FoodClassificationMapper
{
    public static FoodClassificationResponse Map(FoodClassification entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Active);
}