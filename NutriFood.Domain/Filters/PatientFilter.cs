namespace NutriFood.Domain.Filters;

public sealed class PatientFilter
{
    public short? UserId { get; init; }

    public string? Search { get; init; }
}
