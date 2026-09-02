using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class FoodMapper
{
    public static FoodResponse Map(Food entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Description,
        entity.FoodCategoryId,
        entity.FoodClassificationId,
        entity.ImageUrl,
        entity.Active);

    public static Food ToEntity(FoodCreateRequest request) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        FoodCategoryId = request.FoodCategoryId,
        FoodClassificationId = request.FoodClassificationId,
        ImageUrl = request.ImageUrl,
        Active = true
    };

    public static Food ToEntity(FoodUpdateRequest request, Food existing) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        FoodCategoryId = request.FoodCategoryId,
        FoodClassificationId = request.FoodClassificationId,
        ImageUrl = request.ImageUrl,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}