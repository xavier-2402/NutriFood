using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class FoodClassificationsController : ReadOnlyControllerBase<FoodClassification, short, FoodClassificationResponse>
{
    public FoodClassificationsController(IReadOnlyService<FoodClassification, short> service) : base(service)
    {
    }

    protected override FoodClassificationResponse Map(FoodClassification entity) => FoodClassificationMapper.Map(entity);
}