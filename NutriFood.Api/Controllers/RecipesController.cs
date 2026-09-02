using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class RecipesController : CrudControllerBase<Recipe, int, RecipeCreateRequest, RecipeUpdateRequest, RecipeResponse>
{
    public RecipesController(IRecipeService service) : base(service)
    {
    }

    protected override Recipe ToEntity(RecipeCreateRequest request) => RecipeMapper.ToEntity(request);

    protected override Recipe ToEntity(RecipeUpdateRequest request, Recipe existing) => RecipeMapper.ToEntity(request, existing);

    protected override RecipeResponse Map(Recipe entity) => RecipeMapper.Map(entity);
}