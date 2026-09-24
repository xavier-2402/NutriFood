using NutriFood.Application.Contracts;
using NutriFood.Domain.Filters;

namespace NutriFood.Application.Mappers;

public static class PatientFilterMapper
{
    public static PatientFilter ToFilter(PatientSearchRequest request, short? userId) => new()
    {
        UserId = userId,
        Search = request.Search
    };
}
