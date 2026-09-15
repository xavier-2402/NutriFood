using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IMeasureUnitService
{
    Task<MeasureUnitResponse?> GetByIdAsync(short id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<MeasureUnitResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<MeasureUnitResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<MeasureUnitResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<MeasureUnitResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
}