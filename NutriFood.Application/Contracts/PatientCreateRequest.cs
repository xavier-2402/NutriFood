namespace NutriFood.Application.Contracts;

public sealed record PatientCreateRequest(
    string Code,
    string? IdCard,
    string FirstName,
    string LastName,
    DateTime? DateOfBirth,
    short UserId);