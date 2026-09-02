using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class FoodCategoriesController : ReadOnlyControllerBase<FoodCategory, short, FoodCategoryResponse>
{
    public FoodCategoriesController(IReadOnlyService<FoodCategory, short> service) : base(service)
    {
    }

    protected override FoodCategoryResponse Map(FoodCategory entity) => FoodCategoryMapper.Map(entity);
}