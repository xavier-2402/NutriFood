namespace NutriFood.Application.Contracts;

public sealed record FoodUpdateRequest(
    string Code,
    string Name,
    string? Description,
    short FoodCategoryId,
    short FoodClassificationId,
    string? ImageUrl,
    bool Active);