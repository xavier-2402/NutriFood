namespace NutriFood.Application.Contracts;

public sealed record RecipeUpdateRequest(
    string Code,
    string Name,
    string? Description,
    int FoodMenuId,
    bool Active);