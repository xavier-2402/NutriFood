namespace NutriFood.Application.Contracts;

public sealed record FoodClassificationResponse(
    short Id,
    string Code,
    string Name,
    bool Active);