using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class RecipeFoodMapper
{
    public static RecipeFoodResponse Map(RecipeFood entity) => new(
        entity.RecipeId,
        entity.FoodId,
        entity.Quantity,
        entity.MeasureUnitId,
        entity.Active);

    public static RecipeFood ToEntity(RecipeFoodCreateRequest request) => new()
    {
        RecipeId = request.RecipeId,
        FoodId = request.FoodId,
        Quantity = request.Quantity,
        MeasureUnitId = request.MeasureUnitId,
        Active = true
    };
}
