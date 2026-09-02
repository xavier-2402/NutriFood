using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class FoodsController : CrudControllerBase<Food, int, FoodCreateRequest, FoodUpdateRequest, FoodResponse>
{
    public FoodsController(IFoodService service) : base(service)
    {
    }

    protected override Food ToEntity(FoodCreateRequest request) => FoodMapper.ToEntity(request);

    protected override Food ToEntity(FoodUpdateRequest request, Food existing) => FoodMapper.ToEntity(request, existing);

    protected override FoodResponse Map(Food entity) => FoodMapper.Map(entity);
}