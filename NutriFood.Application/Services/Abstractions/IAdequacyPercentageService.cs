using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IAdequacyPercentageService
{
    Task<AdequacyPercentageResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<AdequacyPercentageResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<AdequacyPercentageResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<AdequacyPercentageResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<AdequacyPercentageResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<AdequacyPercentageResponse> CreateAsync(AdequacyPercentageCreateRequest request, CancellationToken cancellationToken);
    Task<AdequacyPercentageResponse?> UpdateAsync(int id, AdequacyPercentageUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
}