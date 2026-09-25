using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Common.Exceptions;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;
    private readonly IFoodMenuRepository _foodMenuRepository;
    private readonly IValidator<RecipeCreateRequest> _createValidator;

    public RecipeService(
        IRecipeRepository repository,
        IFoodMenuRepository foodMenuRepository,
        IValidator<RecipeCreateRequest> createValidator)
    {
        _repository = repository;
        _foodMenuRepository = foodMenuRepository;
        _createValidator = createValidator;
    }

    public async Task<RecipeResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : RecipeMapper.Map(entity);
    }

    public async Task<IReadOnlyList<RecipeResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(RecipeMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<RecipeResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(RecipeMapper.Map).ToList();
    }

    public async Task<RecipeResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : RecipeMapper.Map(entity);
    }

    public async Task<RecipeResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : RecipeMapper.Map(entity);
    }

    public async Task<RecipeResponse> CreateAsync(RecipeCreateRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        const short userId = 1;
        _ = await _foodMenuRepository.GetByIdAndUserIdAsync(request.FoodMenuId, userId, cancellationToken)
            ?? throw new NotFoundException(ErrorMessages.FoodMenuNotFound);

        Recipe entity = RecipeMapper.ToEntity(request);
        entity.Code = CodeGenerator.Generate();
        entity.SetInitialData(userId);

        var created = await _repository.AddAsync(entity, cancellationToken);
        return RecipeMapper.Map(created);
    }

    public async Task<RecipeResponse?> UpdateAsync(int id, RecipeUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = RecipeMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return RecipeMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}
