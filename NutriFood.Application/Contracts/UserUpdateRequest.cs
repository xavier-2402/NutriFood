namespace NutriFood.Application.Contracts;

public sealed record UserUpdateRequest(
    string Code,
    string FirstName,
    string LastName,
    string Email,
    bool Active);