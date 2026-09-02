using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class PatientMapper
{
    public static PatientResponse Map(Patient entity) => new(
        entity.Id,
        entity.Code,
        entity.IdCard,
        entity.FirstName,
        entity.LastName,
        entity.DateOfBirth,
        entity.UserId,
        entity.Active);

    public static Patient ToEntity(PatientCreateRequest request) => new()
    {
        Code = request.Code,
        IdCard = request.IdCard,
        FirstName = request.FirstName,
        LastName = request.LastName,
        DateOfBirth = request.DateOfBirth,
        UserId = request.UserId,
        Active = true
    };

    public static Patient ToEntity(PatientUpdateRequest request, Patient existing) => new()
    {
        Code = request.Code,
        IdCard = request.IdCard,
        FirstName = request.FirstName,
        LastName = request.LastName,
        DateOfBirth = request.DateOfBirth,
        UserId = request.UserId,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}