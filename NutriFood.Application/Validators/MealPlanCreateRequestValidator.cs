using FluentValidation;
using NutriFood.Application.Common;
using NutriFood.Application.Contracts;

namespace NutriFood.Application.Validators;

public sealed class MealPlanCreateRequestValidator : AbstractValidator<MealPlanCreateRequest>
{
    public MealPlanCreateRequestValidator()
    {
        RuleFor(request => request.Name)
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage(ValidationMessages.Required)
            .MaximumLength(250)
            .WithMessage(ValidationMessages.MaximumLength);

        RuleFor(request => request.AdequacyPercentageId)
            .GreaterThan(0)
            .WithMessage(ValidationMessages.GreaterThanZero);
    }
}
