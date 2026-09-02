namespace NutriFood.Application.Contracts;

public sealed record AdequacyPercentageCreateRequest(
    string Code,
    string Title,
    string? Description,
    int PatientId);