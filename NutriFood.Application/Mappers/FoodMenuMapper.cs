using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class FoodMenuMapper
{
    public static FoodMenuResponse Map(FoodMenu entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Description,
        entity.MealPlanId,
        entity.MealTimeId,
        entity.Active);

    public static FoodMenu ToEntity(FoodMenuCreateRequest request) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        MealPlanId = request.MealPlanId,
        MealTimeId = request.MealTimeId,
        Active = true
    };

    public static FoodMenu ToEntity(FoodMenuUpdateRequest request, FoodMenu existing) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        MealPlanId = request.MealPlanId,
        MealTimeId = request.MealTimeId,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}