namespace NutriFood.Application.Contracts;

public sealed record FoodCategoryResponse(
    short Id,
    string Code,
    string Name,
    bool Active);