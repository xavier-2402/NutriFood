using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class AdequacyPercentageMapper
{
    public static AdequacyPercentageResponse Map(AdequacyPercentage entity) => new(
        entity.Id,
        entity.Code,
        entity.Title,
        entity.Description,
        entity.PatientId,
        entity.Active);

    public static AdequacyPercentage ToEntity(AdequacyPercentageCreateRequest request) => new()
    {
        Code = request.Code,
        Title = request.Title,
        Description = request.Description,
        PatientId = request.PatientId,
        Active = true
    };

    public static AdequacyPercentage ToEntity(AdequacyPercentageUpdateRequest request, AdequacyPercentage existing) => new()
    {
        Code = request.Code,
        Title = request.Title,
        Description = request.Description,
        PatientId = request.PatientId,
        Active = request.Active,
        CreaDate = existing.CreaDate,
        CreaUsr = existing.CreaUsr
    };
}