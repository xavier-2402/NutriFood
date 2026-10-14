namespace NutriFood.Application.Contracts;

public sealed record FoodResponse(
    int Id,
    string Code,
    string Name,
    string? Description,
    short FoodCategoryId,
    string? FoodCategoryName,
    short? FoodClassificationId,
    string? FoodClassificationName,
    string? ImageUrl,
    bool Active,
    IReadOnlyList<FoodAttributeValueResponse> Attributes);