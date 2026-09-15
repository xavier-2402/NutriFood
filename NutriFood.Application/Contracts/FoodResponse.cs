namespace NutriFood.Application.Contracts;

public sealed record FoodResponse(
    int Id,
    string Code,
    string Name,
    string? Description,
    short FoodCategoryId,
    short? FoodClassificationId,
    string? ImageUrl,
    bool Active);