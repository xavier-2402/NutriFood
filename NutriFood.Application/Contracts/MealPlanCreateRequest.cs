namespace NutriFood.Application.Contracts;

public sealed record MealPlanCreateRequest(
    string Name,
    string? Description,
    int AdequacyPercentageId);