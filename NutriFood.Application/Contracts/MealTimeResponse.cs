namespace NutriFood.Application.Contracts;

public sealed record MealTimeResponse(
    short Id,
    string Code,
    string Name,
    bool Active);