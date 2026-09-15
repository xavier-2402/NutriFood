using NutriFood.Application.Contracts;

namespace NutriFood.Application.Services.Abstractions;

public interface IPatientService
{
    Task<PatientResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken);
    Task<IReadOnlyList<PatientResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<PatientResponse>> GetAllActiveAsync(CancellationToken cancellationToken);
    Task<PatientResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken);
    Task<PatientResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken);
    Task<PatientResponse> CreateAsync(PatientCreateRequest request, CancellationToken cancellationToken);
    Task<PatientResponse?> UpdateAsync(int id, PatientUpdateRequest request, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken);
}