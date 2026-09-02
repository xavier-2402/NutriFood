using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class RecipeMapper
{
    public static RecipeResponse Map(Recipe entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Description,
        entity.FoodMenuId,
        entity.Active);

    public static Recipe ToEntity(RecipeCreateRequest request) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        FoodMenuId = request.FoodMenuId,
        Active = true
    };

    public static Recipe ToEntity(RecipeUpdateRequest request, Recipe existing) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        FoodMenuId = request.FoodMenuId,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}