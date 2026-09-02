using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class MealTimesController : ReadOnlyControllerBase<MealTime, short, MealTimeResponse>
{
    public MealTimesController(IReadOnlyService<MealTime, short> service) : base(service)
    {
    }

    protected override MealTimeResponse Map(MealTime entity) => MealTimeMapper.Map(entity);
}