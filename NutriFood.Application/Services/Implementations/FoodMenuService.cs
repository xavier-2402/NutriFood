using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Common.Exceptions;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class FoodMenuService : IFoodMenuService
{
    private readonly IFoodMenuRepository _repository;
    private readonly IMealPlanRepository _mealPlanRepository;
    private readonly ICrudRepository<MealTime, short> _mealTimeRepository;
    private readonly IValidator<FoodMenuCreateRequest> _createValidator;

    public FoodMenuService(
        IFoodMenuRepository repository,
        IMealPlanRepository mealPlanRepository,
        ICrudRepository<MealTime, short> mealTimeRepository,
        IValidator<FoodMenuCreateRequest> createValidator)
    {
        _repository = repository;
        _mealPlanRepository = mealPlanRepository;
        _mealTimeRepository = mealTimeRepository;
        _createValidator = createValidator;
    }

    public async Task<FoodMenuResponse?> GetByIdAsync(int id, bool includeInactive, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(id, includeInactive, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<IReadOnlyList<FoodMenuResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync(cancellationToken);
        return entities.Select(FoodMenuMapper.Map).ToList();
    }

    public async Task<IReadOnlyList<FoodMenuResponse>> GetAllActiveAsync(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllActiveAsync(cancellationToken);
        return entities.Select(FoodMenuMapper.Map).ToList();
    }

    public async Task<FoodMenuResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<FoodMenuResponse?> GetActiveByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetActiveByCodeAsync(code, cancellationToken);
        return entity is null ? null : FoodMenuMapper.Map(entity);
    }

    public async Task<FoodMenuResponse> CreateAsync(FoodMenuCreateRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        const short userId = 1;
        _ = await _mealPlanRepository.GetByIdAndUserIdAsync(request.MealPlanId, userId, cancellationToken)
            ?? throw new NotFoundException(ErrorMessages.MealPlanNotFound);

        if (request.MealTimeId.HasValue)
        {
            _ = await _mealTimeRepository.GetByIdAsync(request.MealTimeId.Value,false, cancellationToken)
                ?? throw new NotFoundException(ErrorMessages.MealTimeNotFound);
        }

        FoodMenu entity = FoodMenuMapper.ToEntity(request);
        entity.Code = CodeGenerator.Generate(20);
        entity.SetInitialData(userId);
        var created = await _repository.AddAsync(entity, cancellationToken);
        return FoodMenuMapper.Map(created);
    }

    public async Task<FoodMenuResponse?> UpdateAsync(int id, FoodMenuUpdateRequest request, CancellationToken cancellationToken)
    {
        var existing = await _repository.GetByIdAsync(id, includeInactive: true, cancellationToken);
        if (existing is null)
        {
            return null;
        }

        var entity = FoodMenuMapper.ToEntity(request, existing);
        entity.Id = existing.Id;
        await _repository.UpdateAsync(entity, cancellationToken);
        return FoodMenuMapper.Map(entity);
    }

    public Task<bool> DeleteAsync(int id, short modifiedBy, CancellationToken cancellationToken)
        => _repository.SoftDeleteAsync(id, modifiedBy, cancellationToken);
}