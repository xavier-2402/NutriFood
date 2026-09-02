namespace NutriFood.Application.Contracts;

public sealed record MealPlanUpdateRequest(
    string Code,
    string Name,
    string? Description,
    int AdequacyPercentageId,
    bool Active);