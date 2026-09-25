using Microsoft.EntityFrameworkCore;
using NutriFood.Domain.Common.Pagination;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Filters;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class PatientRepository(NutriFoodDbContext context) : EfCrudRepository<Patient, int>(context), IPatientRepository
{
    public Task<Patient?> GetByIdAndUserIdAsync(int patientId, short userId, CancellationToken cancellationToken)
    {
        return Context.Patients
            .AsNoTracking()
            .FirstOrDefaultAsync(patient =>
                patient.Id == patientId &&
                patient.UserId == userId &&
                patient.Active,
                cancellationToken);
    }

    public async Task<PageResult<Patient>> SearchAsync(
        PatientFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken)
    {
        var query = BuildSearchQuery(filter);
        var totalItems = await query.CountAsync(cancellationToken);
        var items = await query
            .OrderBy(patient => patient.FirstName)
            .ThenBy(patient => patient.LastName)
            .ThenBy(patient => patient.Id)
            .Skip(pagination.Skip)
            .Take(pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PageResult<Patient>(items, pagination.Page, pagination.PageSize, totalItems);
    }

    private IQueryable<Patient> BuildSearchQuery(PatientFilter filter)
    {
        IQueryable<Patient> query = Context.Patients
            .AsNoTracking()
            .Where(patient => patient.Active);

        if (filter.UserId.HasValue)
        {
            query = query.Where(patient => patient.UserId == filter.UserId.Value);
        }

        var normalizedSearch = filter.Search?.Trim();
        if (!string.IsNullOrWhiteSpace(normalizedSearch))
        {
            query = query.Where(patient =>
                EF.Functions.ILike(patient.IdCard ?? "", $"%{normalizedSearch}%") ||
                EF.Functions.ILike(patient.FirstName, $"%{normalizedSearch}%") ||
                EF.Functions.ILike(patient.LastName, $"%{normalizedSearch}%"));
        }

        return query;
    }
}
