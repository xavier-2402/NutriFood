namespace NutriFood.Application.Contracts;

public sealed record MeasureUnitResponse(
    short Id,
    string Name,
    string Abbreviation,
    string Code,
    bool Active);