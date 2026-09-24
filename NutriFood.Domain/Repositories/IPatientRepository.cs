using NutriFood.Domain.Common.Pagination;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Filters;
namespace NutriFood.Domain.Repositories;
public interface IPatientRepository : ICrudRepository<Patient, int>
{
    Task<PageResult<Patient>> SearchAsync(
        PatientFilter filter,
        Pagination pagination,
        CancellationToken cancellationToken);
}
