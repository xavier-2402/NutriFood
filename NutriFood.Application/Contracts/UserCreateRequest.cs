namespace NutriFood.Application.Contracts;

public sealed record UserCreateRequest(
    string Code,
    string FirstName,
    string LastName,
    string Email,
    string Password);