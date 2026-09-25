namespace NutriFood.Application.Contracts;

public sealed class AdequacyAttributeValueCreateRequest
{
    public short AttributeId { get; init; }

    public double Percentage { get; init; }
}
