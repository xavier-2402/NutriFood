using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class RecipeService : CrudService<Recipe, int>, IRecipeService
{
    public RecipeService(IRecipeRepository repository) : base(repository)
    {
    }
}