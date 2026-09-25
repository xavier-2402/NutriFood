namespace NutriFood.Application.Contracts;

public sealed class AdequacyPercentageCreateRequest
{
    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int PatientId { get; init; }

    public List<AdequacyAttributeValueCreateRequest> AttributeValues { get; init; } = [];
}
