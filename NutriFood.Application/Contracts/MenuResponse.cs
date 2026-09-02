namespace NutriFood.Application.Contracts;

public sealed record MenuResponse(
    short Id,
    string Code,
    string Name,
    string Path,
    bool Active);