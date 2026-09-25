using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators;

public sealed class RecipeFoodCreateRequestValidator : AbstractValidator<RecipeFoodCreateRequest>
{
    public RecipeFoodCreateRequestValidator()
    {
        RuleFor(request => request.RecipeId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.FoodId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.Quantity)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);

        RuleFor(request => request.MeasureUnitId)
            .GreaterThan((short)0)
            .WithMessage(ValidationMessages.GreaterThanZero);
    }
}
