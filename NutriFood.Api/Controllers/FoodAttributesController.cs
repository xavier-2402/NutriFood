using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class FoodAttributesController : ReadOnlyControllerBase<FoodAttribute, short, FoodAttributeResponse>
{
    public FoodAttributesController(IReadOnlyService<FoodAttribute, short> service) : base(service)
    {
    }

    protected override FoodAttributeResponse Map(FoodAttribute entity) => FoodAttributeMapper.Map(entity);
}