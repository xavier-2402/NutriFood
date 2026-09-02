using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class MealPlanMapper
{
    public static MealPlanResponse Map(MealPlan entity) => new(
        entity.Id,
        entity.Code,
        entity.Name,
        entity.Description,
        entity.AdequacyPercentageId,
        entity.Active);

    public static MealPlan ToEntity(MealPlanCreateRequest request) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        AdequacyPercentageId = request.AdequacyPercentageId,
        Active = true
    };

    public static MealPlan ToEntity(MealPlanUpdateRequest request, MealPlan existing) => new()
    {
        Code = request.Code,
        Name = request.Name,
        Description = request.Description,
        AdequacyPercentageId = request.AdequacyPercentageId,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}