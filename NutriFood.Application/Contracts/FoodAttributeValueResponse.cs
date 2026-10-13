namespace NutriFood.Application.Contracts;

public sealed record FoodAttributeValueResponse(
    string AttributeName,
    double Value,
    string? MeasureUnitName,
    string? MeasureUnitAbbreviation);
