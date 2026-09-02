namespace NutriFood.Application.Contracts;

public sealed record RecipeResponse(
    int Id,
    string Code,
    string Name,
    string? Description,
    int FoodMenuId,
    bool Active);