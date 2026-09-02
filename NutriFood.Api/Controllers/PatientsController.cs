using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class PatientsController : CrudControllerBase<Patient, int, PatientCreateRequest, PatientUpdateRequest, PatientResponse>
{
    public PatientsController(IPatientService service) : base(service)
    {
    }

    protected override Patient ToEntity(PatientCreateRequest request) => PatientMapper.ToEntity(request);

    protected override Patient ToEntity(PatientUpdateRequest request, Patient existing) => PatientMapper.ToEntity(request, existing);

    protected override PatientResponse Map(Patient entity) => PatientMapper.Map(entity);
}