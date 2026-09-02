namespace NutriFood.Application.Contracts;

public sealed record AdequacyPercentageUpdateRequest(
    string Code,
    string Title,
    string? Description,
    int PatientId,
    bool Active);