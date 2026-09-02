namespace NutriFood.Application.Contracts;

public sealed record MealPlanCreateRequest(
    string Code,
    string Name,
    string? Description,
    int AdequacyPercentageId);