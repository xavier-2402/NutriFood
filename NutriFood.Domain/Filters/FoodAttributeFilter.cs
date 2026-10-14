namespace NutriFood.Domain.Filters;

public sealed record FoodAttributeFilter(
    short AttributeId,
    AttributeComparisonOperatorEnum Operator,
    double Value);
