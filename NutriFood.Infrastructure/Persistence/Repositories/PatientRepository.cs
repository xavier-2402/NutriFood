using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;
using NutriFood.Infrastructure.Persistence.Context;

namespace NutriFood.Infrastructure.Persistence.Repositories;

public sealed class PatientRepository(NutriFoodDbContext context) : EfCrudRepository<Patient, int>(context), IPatientRepository
{
}
