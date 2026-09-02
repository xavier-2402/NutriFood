namespace NutriFood.Application.Contracts;

public sealed record FoodAttributeResponse(
    short Id,
    string Code,
    string Name,
    string? Description,
    short MeasureUnitId,
    bool Active);