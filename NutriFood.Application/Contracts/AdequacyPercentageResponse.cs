namespace NutriFood.Application.Contracts;

public sealed record AdequacyPercentageResponse(
    int Id,
    string Code,
    string Title,
    string? Description,
    int PatientId,
    bool Active);