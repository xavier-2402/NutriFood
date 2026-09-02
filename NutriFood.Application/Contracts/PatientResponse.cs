namespace NutriFood.Application.Contracts;

public sealed record PatientResponse(
    int Id,
    string Code,
    string? IdCard,
    string FirstName,
    string LastName,
    DateTime? DateOfBirth,
    short UserId,
    bool Active);