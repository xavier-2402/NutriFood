using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class PatientService : CrudService<Patient, int>, IPatientService
{
    public PatientService(IPatientRepository repository) : base(repository)
    {
    }
}