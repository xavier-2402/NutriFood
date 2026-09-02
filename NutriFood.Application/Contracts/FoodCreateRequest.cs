namespace NutriFood.Application.Contracts;

public sealed record FoodCreateRequest(
    string Code,
    string Name,
    string? Description,
    short FoodCategoryId,
    short FoodClassificationId,
    string? ImageUrl);