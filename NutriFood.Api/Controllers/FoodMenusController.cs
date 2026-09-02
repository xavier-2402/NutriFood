using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class FoodMenusController : CrudControllerBase<FoodMenu, int, FoodMenuCreateRequest, FoodMenuUpdateRequest, FoodMenuResponse>
{
    public FoodMenusController(IFoodMenuService service) : base(service)
    {
    }

    protected override FoodMenu ToEntity(FoodMenuCreateRequest request) => FoodMenuMapper.ToEntity(request);

    protected override FoodMenu ToEntity(FoodMenuUpdateRequest request, FoodMenu existing) => FoodMenuMapper.ToEntity(request, existing);

    protected override FoodMenuResponse Map(FoodMenu entity) => FoodMenuMapper.Map(entity);
}