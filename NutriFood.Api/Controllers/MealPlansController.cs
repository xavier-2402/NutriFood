using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class MealPlansController : CrudControllerBase<MealPlan, int, MealPlanCreateRequest, MealPlanUpdateRequest, MealPlanResponse>
{
    public MealPlansController(IMealPlanService service) : base(service)
    {
    }

    protected override MealPlan ToEntity(MealPlanCreateRequest request) => MealPlanMapper.ToEntity(request);

    protected override MealPlan ToEntity(MealPlanUpdateRequest request, MealPlan existing) => MealPlanMapper.ToEntity(request, existing);

    protected override MealPlanResponse Map(MealPlan entity) => MealPlanMapper.Map(entity);
}