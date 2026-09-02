namespace NutriFood.Application.Contracts;

public sealed record PatientUpdateRequest(
    string Code,
    string? IdCard,
    string FirstName,
    string LastName,
    DateTime? DateOfBirth,
    short UserId,
    bool Active);