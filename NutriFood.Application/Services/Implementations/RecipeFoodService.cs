using FluentValidation;
using FluentValidation.Results;
using NutriFood.Application.Common;
using NutriFood.Application.Common.Exceptions;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class RecipeFoodService : IRecipeFoodService
{
    private readonly IRecipeFoodRepository _repository;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IFoodRepository _foodRepository;
    private readonly ICrudRepository<MeasureUnit, short> _measureUnitRepository;
    private readonly IValidator<RecipeFoodCreateRequest> _createValidator;

    public RecipeFoodService(
        IRecipeFoodRepository repository,
        IRecipeRepository recipeRepository,
        IFoodRepository foodRepository,
        ICrudRepository<MeasureUnit, short> measureUnitRepository,
        IValidator<RecipeFoodCreateRequest> createValidator)
    {
        _repository = repository;
        _recipeRepository = recipeRepository;
        _foodRepository = foodRepository;
        _measureUnitRepository = measureUnitRepository;
        _createValidator = createValidator;
    }

    public async Task<RecipeFoodResponse> CreateAsync(RecipeFoodCreateRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _createValidator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        const short userId = 1;
        _ = await _recipeRepository.GetByIdAndUserIdAsync(request.RecipeId, userId, cancellationToken)
            ?? throw new NotFoundException(ErrorMessages.RecipeNotFound);

        var food = await _foodRepository.GetActiveWithAttributeValuesAsync(request.FoodId, cancellationToken)
            ?? throw new NotFoundException(ErrorMessages.FoodNotFound);

        var measureUnit = await _measureUnitRepository.GetByIdAsync(request.MeasureUnitId, includeInactive: false, cancellationToken)
            ?? throw new NotFoundException(ErrorMessages.MeasureUnitNotFound);

        if (!string.Equals(measureUnit.Abbreviation, "g", StringComparison.OrdinalIgnoreCase))
        {
            throw new ValidationException([
                new ValidationFailure(nameof(request.MeasureUnitId), ValidationMessages.GramMeasureUnitRequired)
            ]);
        }

        var entity = RecipeFoodMapper.ToEntity(request);
        entity.CreaUsr = userId;
        entity.ModUsr = userId;
        entity.RecipeFoodAttributeValues = food.FoodAttributeValues
            .Where(attributeValue => attributeValue.Active && attributeValue.Attribute?.Active == true)
            .Select(attributeValue => new RecipeFoodAttributeValue
            {
                AttributeId = attributeValue.AttributeId,
                // Food attribute values are expressed per 100 g.
                Value = attributeValue.Value * request.Quantity / 100d,
                Active = true,
                CreaUsr = userId,
                ModUsr = userId
            })
            .ToList();

        var created = await _repository.AddAsync(entity, cancellationToken);
        return RecipeFoodMapper.Map(created);
    }
}