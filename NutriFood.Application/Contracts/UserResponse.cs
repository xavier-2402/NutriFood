namespace NutriFood.Application.Contracts;

public sealed record UserResponse(
    short Id,
    string Code,
    string FirstName,
    string LastName,
    string Email,
    bool Active);