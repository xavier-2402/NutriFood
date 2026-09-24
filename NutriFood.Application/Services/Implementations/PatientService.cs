using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IValidator<PatientCreateRequest> _createValidator;

    public PatientService(IPatientRepository repository, IValidator<PatientCreateRequest> createValidator)
    {
        _repository = repository;
        _createValidator = createValidator;
    }

    public async Task<PatientResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : PatientMapper.Map(entity);
    }

    public async Task<IReadOnlyList<PatientResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(PatientMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<PatientResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(PatientMapper.Map).ToList();
    }

    public async Task<PatientResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : PatientMapper.Map(entity);
    }

    public async Task<PatientResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : PatientMapper.Map(entity);
    }

    public async Task<PatientResponse> CreateAsync(PatientCreateRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var entity = PatientMapper.ToEntity(request);
        entity.Code = CodeGenerator.Generate();
        entity.CreaUsr = 1;
        entity.ModUsr = 1;
        entity.UserId = 1;
        var created = await _repository.AddAsync(entity, cancellationToken);
        return PatientMapper.Map(created);
    }

    public async Task<PatientResponse?> UpdateAsync(int id, PatientUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = PatientMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return PatientMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}