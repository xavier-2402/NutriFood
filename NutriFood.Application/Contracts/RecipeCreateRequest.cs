namespace NutriFood.Application.Contracts;

public sealed record RecipeCreateRequest(
    string Code,
    string Name,
    string? Description,
    int FoodMenuId);