namespace NutriFood.Application.Contracts;

public sealed record PatientCreateRequest(
    string? IdCard,
    string FirstName,
    string LastName,
    DateTime? DateOfBirth);