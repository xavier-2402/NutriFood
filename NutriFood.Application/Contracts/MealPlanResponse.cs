namespace NutriFood.Application.Contracts;

public sealed record MealPlanResponse(
    int Id,
    string Code,
    string Name,
    string? Description,
    int AdequacyPercentageId,
    bool Active);